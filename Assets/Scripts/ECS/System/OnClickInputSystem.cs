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
            
            var filterCamera = world.Filter<CameraFollowComponent>().End();
            var poolCamera = world.GetPool<CameraFollowComponent>();
            
            var filterTarget = world.Filter<TargetPointComponent>().End();
            var poolTarget = world.GetPool<TargetPointComponent>();

            var onClick = ECSInputService.OnClick;
            if (!onClick) return;

            var mousePosition = ECSInputService.MousePosition;

            foreach (var cameraEntity in filterCamera)
            foreach (var targetEntity in filterTarget)
            {
                ref var cameraFollowComponent = ref poolCamera.Get(cameraEntity);
                ref var targetPointComponent = ref poolTarget.Get(targetEntity);

                if (ECSRaycastService.GetPosition(mousePosition, out var targetPosition))
                {
                    targetPointComponent.Position = targetPosition;
                }
            }
        }
    }
}