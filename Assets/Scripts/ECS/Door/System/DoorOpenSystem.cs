using ECS.Components;
using ECS.Services;
using ECS.Door.Components;
using Leopotam.EcsLite;

namespace ECS.Door.System
{
    public class DoorOpenSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var buttonFilter = systems.GetWorld().Filter<DoorComponent>()
                .Inc<TransformComponent>()
                .Inc<ButtonActivateComponent>()
                .Inc<DoorStartPositionComponent>()
                .Inc<DoorEndPositionComponent>().End();
            var transformPool = systems.GetWorld().GetPool<TransformComponent>();
            var buttonActivationPool = systems.GetWorld().GetPool<ButtonActivateComponent>();
            var doorStartPositionPool = systems.GetWorld().GetPool<DoorStartPositionComponent>();
            var doorEndPositionPool = systems.GetWorld().GetPool<DoorEndPositionComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonActivationPool.Get(buttonEntity);
                ref var doorTransformComponent = ref transformPool.Get(buttonEntity);
                ref var doorStartPositionComponent = ref doorStartPositionPool.Get(buttonEntity);
                ref var doorEndPositionComponent = ref doorEndPositionPool.Get(buttonEntity);
                
                if (buttonComponent.IsActivate)
                {
                    doorTransformComponent.Position = Vector3.Lerp(doorStartPositionComponent.Position, 
                        doorEndPositionComponent.Position, buttonComponent.Progress);
                    doorTransformComponent.Rotation = Vector3.Lerp(doorStartPositionComponent.Rotation, 
                        doorEndPositionComponent.Rotation, buttonComponent.Progress);
                }
            }
        }
    }
}