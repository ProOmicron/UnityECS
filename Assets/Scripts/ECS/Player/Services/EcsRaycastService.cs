using UnityEngine;

namespace ECS.Player.Services
{
    public static class EcsRaycastService
    {
        public static bool GetPosition(Vector2 mousePosition, out Vector3 targetPos)
        {
            if (Camera.main != null)
            {
                var hPlane = new Plane(Vector3.up, Vector3.zero);
                var ray = Camera.main.ScreenPointToRay(mousePosition);
                if (hPlane.Raycast(ray, out var distance))
                {
                    targetPos = ray.GetPoint(distance);
                    return true;
                }
            }

            targetPos = Vector3.zero;
            return false;
        }
    }
}