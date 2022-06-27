using ECS.Components;
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

            var onClick = Input.GetMouseButtonDown(0);
            if (!onClick) return;
            Debug.Log("OnClick");

            var mousePosition = Input.mousePosition;

            foreach (var cameraEntity in filterCamera)
            foreach (var targetEntity in filterTarget)
            {
                ref var cameraFollowComponent = ref poolCamera.Get(cameraEntity);
                ref var targetPointComponent = ref poolTarget.Get(targetEntity);
                
                var ray = cameraFollowComponent.Camera.ScreenPointToRay(mousePosition);
                
                if (Physics.Raycast(ray, out var raycastHit))
                {
                    Debug.Log("Hit: " + raycastHit.point);
                    targetPointComponent.Position = raycastHit.point;
                }
            }
        }
    }
}