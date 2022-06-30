using UnityEngine;

namespace ECS.Door.Service
{
    public class EcsColorChangeService
    {
        public static void ChangeColor(GameObject targetObject, Vector3 color)
        {
            var newColor = new Color(color.x, color.y, color.z);
            targetObject.GetComponent<Renderer>().material.color = newColor;
        }
    }
}