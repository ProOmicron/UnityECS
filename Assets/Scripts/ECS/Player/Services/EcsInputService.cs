using UnityEngine;

namespace ECS.Player.Services
{
    public static class EcsInputService
    {
        public static float Horizontal => Input.GetAxis("Horizontal");
        public static float Vertical => Input.GetAxis("Vertical");
        
        public static bool OnClick => Input.GetMouseButtonDown(0);

        public static Vector2 MousePosition => Input.mousePosition;
    }
}