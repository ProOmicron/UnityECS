using ECS.Player.Components;
using ECS.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Player.System
{
    public class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var cameraEntity = world.NewEntity();

            var cameraPool = world.GetPool<CameraFollowComponent>();
            cameraPool.Add(cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(cameraEntity);
            
            var camera = Object.Instantiate(InitData.Load().cameraPrefab, Vector3.zero, Quaternion.identity);
            cameraComponent.CameraTransform = camera.transform;
        }

        public void Run(EcsSystems systems)
        {
            var filterPlayer = systems.GetWorld().Filter<PlayerComponent>().End();
            var poolPlayer = systems.GetWorld().GetPool<PlayerComponent>();
            
            var filterCamera = systems.GetWorld().Filter<CameraFollowComponent>().End();
            var poolCamera = systems.GetWorld().GetPool<CameraFollowComponent>();

            
            foreach (var entityCamera in filterCamera)
            foreach (var entityPlayer in filterPlayer)
            {
                ref var playerComponent = ref poolPlayer.Get(entityPlayer);
                ref var cameraComponent = ref poolCamera.Get(entityCamera);

                cameraComponent.CameraTransform.position = playerComponent.PlayerTransform.position;
            }
        }
    }
}