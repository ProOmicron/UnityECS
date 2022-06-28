using UnityEngine;

namespace ECS.Door.Components
{
    public struct DoorComponent
    {
        public Transform Transform;
    }
    
    public struct DoorStartPositionComponent
    {
        public Vector3 Position;
        public Vector3 Rotation;
    }
    
    public struct DoorEndPositionComponent
    {
        public Vector3 Position;
        public Vector3 Rotation;
    }
    
    public struct ButtonPositionComponent
    {
        public Vector3 Position;
    }
    
    public struct ButtonActivateComponent
    {
        public float ActivationDistance;
        public bool IsActivate;
        public float Progress;
    }
    
    public struct ButtonDoorColorComponent
    {
        public Color Color;
    }
    
    public struct DoorSpeedComponent
    {
        public float OpenCloseSpeed;
    }
}
