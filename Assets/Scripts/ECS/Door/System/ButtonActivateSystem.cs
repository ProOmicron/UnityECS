using ECS.Components;
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
            var buttonFilter = systems.GetWorld().Filter<ButtonActivateComponent>().Inc<ButtonPositionComponent>().Inc<SpeedComponent>().End();
            var buttonPool = systems.GetWorld().GetPool<ButtonActivateComponent>();
            var buttonPositionPool = systems.GetWorld().GetPool<ButtonPositionComponent>();
            var doorSpeedComponentPool = systems.GetWorld().GetPool<SpeedComponent>();
            
            var playerFilter = systems.GetWorld().Filter<PlayerComponent>().Inc<TransformComponent>().End();
            var transformPool = systems.GetWorld().GetPool<TransformComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);
                ref var buttonSpeedComponent = ref doorSpeedComponentPool.Get(buttonEntity);
                var key = false;
                
                foreach (var playerEntity in playerFilter)
                {
                    ref var buttonPositionComponent = ref buttonPositionPool.Get(buttonEntity);
                    ref var transformComponent = ref transformPool.Get(playerEntity);

                    if (Vector3.Distance(buttonPositionComponent.Position, transformComponent.Position) < buttonComponent.ActivationDistance)
                    {
                        key = true;
                    }
                }
                
                buttonComponent.IsActivate = key;
                if (key == true)
                    buttonComponent.Progress += EcsTimeService.DeltaTime * buttonSpeedComponent.Speed;
            }
        }
    }
}