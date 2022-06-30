using ECS.Components;
using ECS.Player.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Player.System
{
    public class LookToMove : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filterPlayer = systems.GetWorld().Filter<PlayerComponent>()
                .Inc<TransformComponent>()
                .Inc<TargetPointComponent>()
                .Inc<MoveDirectionComponent>().End();
            var transformPool = systems.GetWorld().GetPool<TransformComponent>();
            var targetPointPool = systems.GetWorld().GetPool<TargetPointComponent>();
            var moveDirPool = systems.GetWorld().GetPool<MoveDirectionComponent>();

            foreach (var entityPlayer in filterPlayer)
            {
                ref var playerTransformComponent = ref transformPool.Get(entityPlayer);
                ref var moveDirectionComponent = ref moveDirPool.Get(entityPlayer);
                ref var targetPointComponent = ref targetPointPool.Get(entityPlayer);

                if (Vector3.Distance(targetPointComponent.Position, playerTransformComponent.Position) > 1.0f)
                {
                    var angle = Mathf.Rad2Deg *
                                Mathf.Atan2(moveDirectionComponent.Direction.x, moveDirectionComponent.Direction.z);

                    playerTransformComponent.Rotation = new Vector3(0.0f, angle, 0.0f);
                }
            }
        }
    }
}