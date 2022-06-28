using UnityEngine;

namespace ECS.ScriptableObjects
{
    [System.Serializable]
    public struct DoorButtonInfo
    {
        public Vector3 DoorStartPosition;
        public Vector3 DoorStartRotation;
        public Vector3 DoorEndPosition;
        public Vector3 DoorEndRotation;
        public Vector3 ButtonPosition;
        public float MoveSpeed;
        public Color Color;
    }
    [CreateAssetMenu]
    public class InitData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float defaultSpeed = 2f;
        public GameObject cameraPrefab;
        
        //Door and Button
        public GameObject doorPrefab;
        public GameObject buttonPrefab;
        public float buttonActivationDistance;
        [SerializeField]
        public DoorButtonInfo[] DoorButtonInfos;

        public static InitData Load()
        {
            return Resources.Load<InitData>("Data/PlayerInitData");
        }
    }
}