using ECS.Player.Components;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class MoveToPointSystem: IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().Inc<MoveDirectionComponent>().Inc<TargetPointComponent>().End();
            var pool = world.GetPool<MoveDirectionComponent>();
            var pointPool = world.GetPool<TargetPointComponent>();
            var playerPool = world.GetPool<PlayerComponent>();
        
            foreach (var entity in filter)
            {
                ref var moveDirectionComponent = ref pool.Get(entity);
                ref var targetToPointComponent = ref pointPool.Get(entity);
                ref var playerComponent = ref playerPool.Get(entity);

                var position = playerComponent.PlayerTransform.position;
                moveDirectionComponent.Direction = (targetToPointComponent.Position - position).normalized;
            }
        }
    }
}