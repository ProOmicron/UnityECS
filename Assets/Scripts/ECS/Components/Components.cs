using UnityEngine;

namespace ECS.Components
{
    public struct PlayerComponent
    {
        public Transform PlayerTransform;
        public CapsuleCollider PlayerCollider;
    }

    public struct MoveDirectionComponent
    {
        public Vector3 Direction;
    }

    public struct MovableComponent
    {
        public Transform EntityTransform;
        public float MoveSpeed;
    }

    public struct CameraFollowComponent
    {
        public Transform CameraTransform;
        public Camera Camera;
    }

    public struct TargetPointComponent
    {
        public Vector3 Position;
    }
}