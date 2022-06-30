using UnityEngine;

namespace ECS.Player.Components
{
    public struct PlayerComponent
    {
        public int EntityID;
    }

    public struct MoveDirectionComponent
    {
        public Vector3 Direction;
    }

    public struct CameraFollowComponent {}

    public struct TargetPointComponent
    {
        public Vector3 Position;
    }
}