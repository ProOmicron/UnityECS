using UnityEngine;

namespace ECS.Player.Services
{
    public static class EcsRaycastService
    {
        public static bool GetPosition(Vector2 mousePosition, out ECS.Services.Vector3 targetPos)
        {
            if (Camera.main != null)
            {
                var hPlane = new Plane(UnityEngine.Vector3.up, UnityEngine.Vector3.zero);
                var ray = Camera.main.ScreenPointToRay(mousePosition);
                if (hPlane.Raycast(ray, out var distance))
                {
                    var point = ray.GetPoint(distance);
                    targetPos = new ECS.Services.Vector3(point.x, point.y, point.z);
                    return true;
                }
            }

            targetPos = ECS.Services.Vector3.zero;
            return false;
        }
    }
}