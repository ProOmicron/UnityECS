using ECS.Door.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Door.System
{
    public class DoorOpenSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var buttonFilter = systems.GetWorld().Filter<DoorComponent>().Inc<ButtonActivateComponent>().Inc<DoorStartPositionComponent>().Inc<DoorEndPositionComponent>().End();
            var doorPool = systems.GetWorld().GetPool<DoorComponent>();
            var buttonActivationPool = systems.GetWorld().GetPool<ButtonActivateComponent>();
            var doorStartPositionPool = systems.GetWorld().GetPool<DoorStartPositionComponent>();
            var doorEndPositionPool = systems.GetWorld().GetPool<DoorEndPositionComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonActivationPool.Get(buttonEntity);
                ref var doorComponent = ref doorPool.Get(buttonEntity);
                ref var doorStartPositionComponent = ref doorStartPositionPool.Get(buttonEntity);
                ref var doorEndPositionComponent = ref doorEndPositionPool.Get(buttonEntity);
                
                if (buttonComponent.IsActivate)
                {
                    doorComponent.Transform.position = Vector3.Lerp(doorStartPositionComponent.Position, 
                        doorEndPositionComponent.Position, buttonComponent.Progress);
                    doorComponent.Transform.rotation = Quaternion.Lerp(Quaternion.Euler(doorStartPositionComponent.Rotation), 
                        Quaternion.Euler(doorEndPositionComponent.Rotation), buttonComponent.Progress);
                }
            }
        }
    }
}