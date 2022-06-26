using UnityEngine;

namespace ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerInitData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float defaultSpeed = 2f;

        public static PlayerInitData Load()
        {
            return Resources.Load<PlayerInitData>("Data/PlayerInitData");
        }
    }
}