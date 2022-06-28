using ECS.Player.Components;
using ECS.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Player.System
{
    public class PlayerSystem : IEcsInitSystem
    {    
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
        
            var playerEntity = world.NewEntity();
            
            var playerComponentPool = world.GetPool<PlayerComponent>();
            playerComponentPool.Add(playerEntity);
            ref var playerComponent = ref playerComponentPool.Get(playerEntity);
        
            var movementComponentPool = world.GetPool<MovableComponent>();
            movementComponentPool.Add(playerEntity);
            ref var movementComponent = ref movementComponentPool.Get(playerEntity);
        
            var moveDirectionComponent = world.GetPool<MoveDirectionComponent>();
            moveDirectionComponent.Add(playerEntity);
            
            var targetPointComponentPool = world.GetPool<TargetPointComponent>();
            targetPointComponentPool.Add(playerEntity);

            var spawnedPlayer = Object.Instantiate(InitData.Load().playerPrefab, Vector3.zero, Quaternion.identity);

            playerComponent.PlayerTransform = spawnedPlayer.transform;
            
            movementComponent.MoveSpeed = InitData.Load().defaultSpeed;
            movementComponent.EntityTransform = spawnedPlayer.transform;
        }
    }
}