using ECSExample.Interfaces;
using ECSExample.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Services
{
    public class GameEntryPoint : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _physicsLoopSystems;
        private EcsSystems _cameraViewSystem;

        public void Initialize(IConfigService configService)
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _physicsLoopSystems = new EcsSystems(_world);
            _cameraViewSystem = new EcsSystems(_world);

            _cameraViewSystem.Add(new CameraViewSystem(configService.CameraConfig));
            _physicsLoopSystems.Add(new SimpleGravitySystem(configService.PhysicsConfig));
            _systems.Add(new PlayerSpawnSystem(configService.PlayerConfig));
            _systems.Add(new PlayerInputSystem());
            _systems.Add(new MovementSystem(configService.PlayerConfig));
            _systems.Add(new AnimationSystem());
            _systems.Add(new BalloonsSystem(configService.BalloonsSystemConfig));

            _physicsLoopSystems.Init();
            _systems.Init();
            _cameraViewSystem.Init();
        }

        private void FixedUpdate()
        {
            _physicsLoopSystems.Run();
        }

        private void Update()
        {
            _cameraViewSystem.Run();
            _systems.Run();
        }

        private void LateUpdate()
        {
            _cameraViewSystem.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}
