using ECS.Components;
using Leopotam.EcsLite;
using ECS.ScriptableObjects;
using UnityEngine;

namespace ECS.System
{
    public class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        private int _cameraEntity;
        
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
            _cameraEntity = world.NewEntity();

            var cameraPool = world.GetPool<CameraFollowComponent>();
            cameraPool.Add(_cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(_cameraEntity);
            
            var camera = Object.Instantiate(InitData.Load().cameraPrefab, Vector3.zero, Quaternion.identity);
            cameraComponent.CameraTransform = camera.transform;
            cameraComponent.Camera = camera.GetComponentInChildren<Camera>();
        }

        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerComponent>().Inc<CameraFollowComponent>().End();
            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();
            var cameraPool = systems.GetWorld().GetPool<CameraFollowComponent>();

            ref var cameraComponent = ref cameraPool.Get(_cameraEntity);

            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);

                cameraComponent.CameraTransform.position = playerComponent.PlayerTransform.position;
            }
        }
    }
}
