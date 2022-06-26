using UnityEngine;

namespace ECS.Components
{
    public struct InputEventComponent { public Vector3 Direction; }

    public struct MovableComponent
    {
        public Transform EntityTransform;
        public float MoveSpeed;
    }
}