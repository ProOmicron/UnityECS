using UnityEngine;

namespace ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class InitData : ScriptableObject
    {
        public GameObject playerPrefab;
        public GameObject cameraPrefab;
        public float defaultSpeed = 2f;

        public static InitData Load()
        {
            return Resources.Load<InitData>("Data/PlayerInitData");
        }
    }
}