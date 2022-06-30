using ECS.Components;
using ECS.MonoBehaviours;
using ECS.Player.Components;
using ECS.ScriptableObjects;
using ECS.Services;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var cameraEntity = world.NewEntity();

            var data = InitData.Load();

            var cameraPool = world.GetPool<CameraFollowComponent>();
            cameraPool.Add(cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(cameraEntity);
            
            var transformPool = world.GetPool<TransformComponent>();
            transformPool.Add(cameraEntity);
            ref var transformComponent = ref transformPool.Get(cameraEntity);
            
            Startup.Spawn(cameraEntity, data.cameraPrefab, data.playerStartPosition, data.playerStartRotation);
            
            transformComponent.Position = Converter.Vec3UnityToEcs(data.playerStartPosition);
            transformComponent.Rotation = Converter.Vec3UnityToEcs(data.playerStartRotation);
        }

        public void Run(EcsSystems systems)
        {
            var filterPlayer = systems.GetWorld().Filter<PlayerComponent>().Inc<TransformComponent>().End();
            var transformPool = systems.GetWorld().GetPool<TransformComponent>();
            
            var filterCamera = systems.GetWorld().Filter<CameraFollowComponent>().Inc<TransformComponent>().End();

            foreach (var entityCamera in filterCamera)
            foreach (var entityPlayer in filterPlayer)
            {
                ref var playerTransformComponent = ref transformPool.Get(entityPlayer);
                ref var cameraTransformComponent = ref transformPool.Get(entityCamera);

                cameraTransformComponent.Position = playerTransformComponent.Position;
            }
        }
    }
}
