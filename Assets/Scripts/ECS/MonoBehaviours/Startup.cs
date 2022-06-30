using System.Collections.Generic;
using ECS.Components;
using ECS.Door.System;
using ECS.Player.System;
using ECS.Services;
using Leopotam.EcsLite;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ECS.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _runSystems;
        
        private static Dictionary<int, GameObject> _entityDictionary;

        private void Awake()
        {
            _entityDictionary = new Dictionary<int, GameObject>();
        }
        
        void Start()
        {
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _runSystems = new EcsSystems(_world);

            _initSystems.Add(new PlayerSystem());
            
            _initSystems.Add(new ButtonDoorInitSystem());
            _initSystems.Init();
            
            //Player
            _runSystems.Add(new CameraSystem());
            _runSystems.Add(new MoveSystem());
            _runSystems.Add(new MoveToPointSystem());
            _runSystems.Add(new OnClickInputSystem());
            _runSystems.Add(new LookToMove());
            
            //Props
            _runSystems.Add(new ButtonActivateSystem());
            _runSystems.Add(new DoorOpenSystem());
            _runSystems.Init();
        }

        void Update()
        {
            UpdateEntityTransforms();
            _runSystems.Run();
        }

        private void UpdateEntityTransforms()
        {
            var transformPool = _world.GetPool<TransformComponent>();
            foreach (var entity in _entityDictionary)
            {
                ref var transformComponent = ref transformPool.Get(entity.Key);
                var objTransform = entity.Value.transform;
                objTransform.position = Converter.Vec3EcsToUnity(transformComponent.Position);
                objTransform.rotation = Quaternion.Euler(Converter.Vec3EcsToUnity(transformComponent.Rotation));
            }
        }

        private void OnDestroy()
        {
            _runSystems.Destroy();
            _initSystems.Destroy();
            _world.Destroy();
            _entityDictionary.Clear();
            _entityDictionary = null;
        }
        
        public static GameObject Spawn(int entityID, GameObject prefab, Vector3 position, Vector3 rotation)
        {
            var spawnedPlayer = Instantiate(prefab, position, Quaternion.Euler(rotation));
            _entityDictionary.Add(entityID, spawnedPlayer);
            return spawnedPlayer;
        }
        
        public static GameObject Spawn(GameObject prefab, Vector3 position, Vector3 rotation)
        {
            var spawnedPlayer =Instantiate(prefab, position, Quaternion.Euler(rotation));
            return spawnedPlayer;
        }

        public static GameObject GetObjectForEntityID(int entityID)
        {
            return _entityDictionary[entityID];
        }
    }
}