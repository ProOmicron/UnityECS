using UnityEngine;

namespace ECS.Services
{
    public static class EcsTimeService
    {
        public static float DeltaTime => Time.deltaTime;
        public static float GameTime => Time.time;
    }
}