using ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.System
{
    public class InputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MoveDirectionComponent>().End();
            var pool = world.GetPool<MoveDirectionComponent>();

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref pool.Get(entity);
                playerInputComponent.Direction = new Vector3(x, 0.0f, y);
            }
        }
    }
}