using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.ScriptableObjects
{
    [System.Serializable]
    public struct DoorButtonInfo
    {
        public Vector3 doorStartPosition;
        public Vector3 doorStartRotation;
        public Vector3 doorEndPosition;
        public Vector3 doorEndRotation;
        public Vector3 buttonPosition;
        public Vector3 buttonRotation;
        public float moveSpeed;
        public Color color;
        public Vector3 GetColor => new Vector3(color.r, color.g, color.b);
    }
    [CreateAssetMenu]
    public class InitData : ScriptableObject
    {
        public GameObject playerPrefab;
        public Vector3 playerStartPosition;
        public Vector3 playerStartRotation;
        public float defaultSpeed = 2f;
        public GameObject cameraPrefab;
        
        //Door and Button
        public GameObject doorPrefab;
        public GameObject buttonPrefab;
        public float buttonActivationDistance;
        public DoorButtonInfo[] doorButtonInfos;

        public static InitData Load()
        {
            return Resources.Load<InitData>("Data/PlayerInitData");
        }
    }
}