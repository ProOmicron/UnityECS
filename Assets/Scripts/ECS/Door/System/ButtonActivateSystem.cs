using ECS.Door.Components;
using ECS.Player.Components;
using ECS.Services;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Door.System
{
    public class ButtonActivateSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var buttonFilter = systems.GetWorld().Filter<ButtonActivateComponent>().Inc<ButtonPositionComponent>().End();
            var buttonPool = systems.GetWorld().GetPool<ButtonActivateComponent>();
            var buttonPositionPool = systems.GetWorld().GetPool<ButtonPositionComponent>();
            
            var playerFilter = systems.GetWorld().Filter<PlayerComponent>().End();
            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);
                var key = false;
                foreach (var playerEntity in playerFilter)
                {
                    ref var buttonPositionComponent = ref buttonPositionPool.Get(buttonEntity);
                    ref var playerComponent = ref playerPool.Get(playerEntity);

                    if (Vector3.Distance(buttonPositionComponent.Position, playerComponent.PlayerTransform.position) < buttonComponent.ActivationDistance)
                    {
                        key = true;
                    }
                }
                buttonComponent.IsActivate = key;
                buttonComponent.Progress += EcsTimeService.DeltaTime * 0.1f;
            }
        }
    }
}