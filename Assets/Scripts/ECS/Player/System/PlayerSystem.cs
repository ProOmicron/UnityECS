using ECS.Components;
using ECS.MonoBehaviours;
using ECS.Player.Components;
using ECS.ScriptableObjects;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class PlayerSystem : IEcsInitSystem
    {    
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
        
            var playerEntity = world.NewEntity();

            var data = InitData.Load();
            
            var playerComponentPool = world.GetPool<PlayerComponent>();
            playerComponentPool.Add(playerEntity);
            ref var playerComponent = ref playerComponentPool.Get(playerEntity);
            
            var transformComponentPool = world.GetPool<TransformComponent>();
            transformComponentPool.Add(playerEntity);
            ref var transformComponent = ref transformComponentPool.Get(playerEntity);
        
            var movementComponentPool = world.GetPool<SpeedComponent>();
            movementComponentPool.Add(playerEntity);
            ref var movementComponent = ref movementComponentPool.Get(playerEntity);
        
            var moveDirectionComponentPool = world.GetPool<MoveDirectionComponent>();
            moveDirectionComponentPool.Add(playerEntity);
            
            var targetPointComponentPool = world.GetPool<TargetPointComponent>();
            targetPointComponentPool.Add(playerEntity);
            
            Startup.Spawn(playerEntity, data.playerPrefab, data.playerStartPosition, data.playerStartRotation);

            playerComponent.EntityID = playerEntity;

            transformComponent.Position = data.playerStartPosition;
            transformComponent.Rotation = data.playerStartRotation;
            
            movementComponent.Speed = InitData.Load().defaultSpeed;
        }
    }
}