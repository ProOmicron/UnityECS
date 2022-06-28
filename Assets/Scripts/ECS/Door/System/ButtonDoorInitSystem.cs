using ECS.Door.Components;
using UnityEngine;
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
            var info = data.DoorButtonInfos;
            
            for (int i = 0; i < info.Length; i++)
            {
                var doorButtonEntity = world.NewEntity();
                
                var doorComponentPool = world.GetPool<DoorComponent>();
                doorComponentPool.Add(doorButtonEntity);
                ref var doorComponent = ref doorComponentPool.Get(doorButtonEntity);

                var buttonPositionComponentPool = world.GetPool<ButtonPositionComponent>();
                buttonPositionComponentPool.Add(doorButtonEntity);
                ref var buttonPosition = ref buttonPositionComponentPool.Get(doorButtonEntity);
                buttonPosition.Position = info[i].ButtonPosition;
            
                var doorStartPositionComponentPool = world.GetPool<DoorStartPositionComponent>();
                doorStartPositionComponentPool.Add(doorButtonEntity);
                ref var doorStartPositionComponent = ref doorStartPositionComponentPool.Get(doorButtonEntity);
                doorStartPositionComponent.Position = info[i].DoorStartPosition;
                doorStartPositionComponent.Rotation = info[i].DoorStartRotation;
            
                var doorEndPositionComponentPool = world.GetPool<DoorEndPositionComponent>();
                doorEndPositionComponentPool.Add(doorButtonEntity);
                ref var doorEndPositionComponent = ref doorEndPositionComponentPool.Get(doorButtonEntity);
                doorEndPositionComponent.Position = info[i].DoorEndPosition;
                doorEndPositionComponent.Rotation = info[i].DoorEndRotation;
            
                var buttonActivateComponentPool = world.GetPool<ButtonActivateComponent>();
                buttonActivateComponentPool.Add(doorButtonEntity);
                ref var buttonActivateComponent = ref buttonActivateComponentPool.Get(doorButtonEntity);
                buttonActivateComponent.IsActivate = false;
                buttonActivateComponent.ActivationDistance = data.buttonActivationDistance;
                buttonActivateComponent.Progress = 0.0f;
            
                var doorSpeedComponentPool = world.GetPool<DoorSpeedComponent>();
                doorSpeedComponentPool.Add(doorButtonEntity);
                ref var doorSpeedComponent = ref doorSpeedComponentPool.Get(doorButtonEntity);
                doorSpeedComponent.OpenCloseSpeed = info[i].MoveSpeed;
            
                var buttonDoorColorComponentPool = world.GetPool<ButtonDoorColorComponent>();
                buttonDoorColorComponentPool.Add(doorButtonEntity);
                ref var buttonDoorColorComponent = ref buttonDoorColorComponentPool.Get(doorButtonEntity);
                buttonDoorColorComponent.Color = info[i].Color;

                var button = Object.Instantiate(data.buttonPrefab, buttonPosition.Position, Quaternion.identity);
                var door = Object.Instantiate(data.doorPrefab, doorStartPositionComponent.Position, Quaternion.Euler(doorStartPositionComponent.Rotation));
                doorComponent.Transform = door.transform;
            }
        }
    }
}