using UnityEngine;

namespace ECS.Components
{
    public struct PlayerComponent
    {
        public Transform PlayerTransform;
        public CapsuleCollider PlayerCollider;
    }
    
    public struct InputEventComponent { public Vector3 Direction; }

    public struct MovableComponent
    {
        public Transform EntityTransform;
        public float MoveSpeed;
    }
    
    public struct CameraFollowComponent
    {
        public Transform CameraTransform;
    }
}