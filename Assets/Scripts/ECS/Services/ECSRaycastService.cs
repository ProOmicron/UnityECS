using UnityEngine;

namespace ECS.Services
{
    public class ECSRaycastService
    {
        public static bool GetPosition(Vector2 mousePosition, out Vector3 targetPos)
        {
            if (Camera.main != null)
            {
                var ray = Camera.main.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(ray, out var raycastHit))
                {
                    targetPos = raycastHit.point;
                    return true;
                }
            }

            targetPos = Vector3.zero;
            return false;
        }
    }
}