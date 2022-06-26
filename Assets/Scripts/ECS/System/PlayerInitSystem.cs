using ECS.Components;
using ECS.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.System
{
    public class PlayerInitSystem : IEcsInitSystem
    {    
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
        
            var playerEntity = world.NewEntity();
        
            var movementComponentPool = world.GetPool<MovableComponent>();
            movementComponentPool.Add(playerEntity);
            ref var movementComponent = ref movementComponentPool.Get(playerEntity);
        
            var inputComponent = world.GetPool<InputEventComponent>();
            inputComponent.Add(playerEntity);

            var spawnedPlayer = Object.Instantiate(PlayerInitData.Load().playerPrefab, Vector3.zero, Quaternion.identity);
            movementComponent.MoveSpeed = PlayerInitData.Load().defaultSpeed;
            movementComponent.EntityTransform = spawnedPlayer.transform;
        }
    }
}