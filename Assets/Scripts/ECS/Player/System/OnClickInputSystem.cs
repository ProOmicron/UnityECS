using ECS.Player.Components;
using ECS.Player.Services;
using Leopotam.EcsLite;

namespace ECS.Player.System
{
    public class OnClickInputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var filterTarget = world.Filter<TargetPointComponent>().End();
            var poolTarget = world.GetPool<TargetPointComponent>();
            
            var onClick = EcsInputService.OnClick;
            if (!onClick) return;

            var mousePosition = EcsInputService.MousePosition;

            foreach (var targetEntity in filterTarget)
            {
                ref var targetPointComponent = ref poolTarget.Get(targetEntity);
                
                if (EcsRaycastService.GetPosition(mousePosition, out var targetPosition))
                {
                    targetPointComponent.Position = targetPosition;
                }
            }
        }
    }
}