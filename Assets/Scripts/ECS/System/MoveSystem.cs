using ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.System
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<MovableComponent>().End();
            var pool = systems.GetWorld().GetPool<MovableComponent>();
            var inputPool = systems.GetWorld().GetPool<InputEventComponent>();
        
            foreach (var entity in filter)
            {
                ref var moveComponent = ref pool.Get(entity);
                ref var inputComponent = ref inputPool.Get(entity);

                moveComponent.EntityTransform.position = (Time.deltaTime * moveComponent.MoveSpeed * inputComponent.Direction.normalized) + moveComponent.EntityTransform.position;
            }
        }
    }
}