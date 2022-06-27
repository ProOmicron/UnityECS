using UnityEngine;

namespace ECS.Services
{
    public class ECSTimeService
    {
        public static float DeltaTime => Time.deltaTime;
        public static float GameTime => Time.time;
    }
}