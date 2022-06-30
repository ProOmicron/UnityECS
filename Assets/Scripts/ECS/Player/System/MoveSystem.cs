using ECS.Components;
using ECS.Player.Components;
using ECS.Services;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<TransformComponent>().Inc<SpeedComponent>().Inc<MoveDirectionComponent>().End();
            var transformPool = systems.GetWorld().GetPool<TransformComponent>();
            var speedPool = systems.GetWorld().GetPool<SpeedComponent>();
            var inputPool = systems.GetWorld().GetPool<MoveDirectionComponent>();
        
            foreach (var entity in filter)
            {
                ref var transform = ref transformPool.Get(entity);
                ref var speed = ref speedPool.Get(entity);
                ref var move = ref inputPool.Get(entity);
                
                transform.Position += (EcsTimeService.DeltaTime * speed.Speed * move.Direction.normalized);
            }
        }
    }
}