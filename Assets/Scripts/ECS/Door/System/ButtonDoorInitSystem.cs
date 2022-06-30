using ECS.Components;
using ECS.Door.Components;
using ECS.Door.Service;
using ECS.MonoBehaviours;
using ECS.ScriptableObjects;
using Leopotam.EcsLite;

namespace ECS.Door.System
{
    public class ButtonDoorInitSystem : IEcsInitSystem
    {    
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var data = InitData.Load();
            var info = data.doorButtonInfos;
            
            for (int i = 0; i < info.Length; i++)
            {
                var doorButtonEntity = world.NewEntity();
                
                var doorComponentPool = world.GetPool<DoorComponent>();
                doorComponentPool.Add(doorButtonEntity);
                ref var doorComponent = ref doorComponentPool.Get(doorButtonEntity);
                
                var doorTransformComponentPool = world.GetPool<TransformComponent>();
                doorTransformComponentPool.Add(doorButtonEntity);
                ref var doorTransformComponent = ref doorTransformComponentPool.Get(doorButtonEntity);
                doorTransformComponent.Position = info[i].doorStartPosition;
                doorTransformComponent.Rotation = info[i].doorStartRotation;

                var buttonPositionComponentPool = world.GetPool<ButtonPositionComponent>();
                buttonPositionComponentPool.Add(doorButtonEntity);
                ref var buttonPosition = ref buttonPositionComponentPool.Get(doorButtonEntity);
                buttonPosition.Position = info[i].buttonPosition;
            
                var doorStartPositionComponentPool = world.GetPool<DoorStartPositionComponent>();
                doorStartPositionComponentPool.Add(doorButtonEntity);
                ref var doorStartPositionComponent = ref doorStartPositionComponentPool.Get(doorButtonEntity);
                doorStartPositionComponent.Position = info[i].doorStartPosition;
                doorStartPositionComponent.Rotation = info[i].doorStartRotation;
            
                var doorEndPositionComponentPool = world.GetPool<DoorEndPositionComponent>();
                doorEndPositionComponentPool.Add(doorButtonEntity);
                ref var doorEndPositionComponent = ref doorEndPositionComponentPool.Get(doorButtonEntity);
                doorEndPositionComponent.Position = info[i].doorEndPosition;
                doorEndPositionComponent.Rotation = info[i].doorEndRotation;
            
                var buttonActivateComponentPool = world.GetPool<ButtonActivateComponent>();
                buttonActivateComponentPool.Add(doorButtonEntity);
                ref var buttonActivateComponent = ref buttonActivateComponentPool.Get(doorButtonEntity);
                buttonActivateComponent.IsActivate = false;
                buttonActivateComponent.ActivationDistance = data.buttonActivationDistance;
                buttonActivateComponent.Progress = 0.0f;
            
                var doorSpeedComponentPool = world.GetPool<SpeedComponent>();
                doorSpeedComponentPool.Add(doorButtonEntity);
                ref var doorSpeedComponent = ref doorSpeedComponentPool.Get(doorButtonEntity);
                doorSpeedComponent.Speed = info[i].moveSpeed;

                var button = Startup.Spawn(data.buttonPrefab, buttonPosition.Position, info[i].buttonRotation);
                var door = Startup.Spawn(doorButtonEntity, data.doorPrefab, doorStartPositionComponent.Position, doorStartPositionComponent.Rotation);
                
                EcsColorChangeService.ChangeColor(button, info[i].GetColor);
                EcsColorChangeService.ChangeColor(door, info[i].GetColor);
            }
        }
    }
}