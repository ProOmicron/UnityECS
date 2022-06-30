using ECS.Components;
using ECS.Player.Components;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class MoveToPointSystem: IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().Inc<TransformComponent>().Inc<MoveDirectionComponent>().Inc<TargetPointComponent>().End();
            var pool = world.GetPool<MoveDirectionComponent>();
            var pointPool = world.GetPool<TargetPointComponent>();
            var transformPool = world.GetPool<TransformComponent>();
        
            foreach (var entity in filter)
            {
                ref var moveDirectionComponent = ref pool.Get(entity);
                ref var targetToPointComponent = ref pointPool.Get(entity);
                ref var transformComponent = ref transformPool.Get(entity);

                moveDirectionComponent.Direction = (targetToPointComponent.Position - transformComponent.Position).normalized;
            }
        }
    }
}