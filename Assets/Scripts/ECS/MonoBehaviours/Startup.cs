using ECS.System;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _runSystems;
        void Start()
        {
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _runSystems = new EcsSystems(_world);

            _initSystems.Add(new PlayerSystem());
            _initSystems.Init();
            
            _runSystems.Add(new CameraSystem());
            //_runSystems.Add(new InputSystem());
            _runSystems.Add(new MoveSystem());
            _runSystems.Add(new MoveToPointSystem());
            _runSystems.Add(new OnClickInputSystem());
            _runSystems.Init();
        }

        void Update()
        {
            _runSystems.Run();
        }

        private void OnDestroy()
        {
            _runSystems.Destroy();
            _initSystems.Destroy();
            _world.Destroy();
        }
    }
}