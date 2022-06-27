using ECS.Components;
using ECS.Services;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.System
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