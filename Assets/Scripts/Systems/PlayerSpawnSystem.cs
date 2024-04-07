using Leopotam.Ecs;
using UnityEngine;
using ECSExample.Components;
using ECSExample.Interfaces;

namespace ECSExample.Systems
{
    public class PlayerSpawnSystem : IEcsInitSystem
    {
        private readonly IPlayerConfig _config;
        private EcsWorld _world = null;
        public PlayerSpawnSystem(IPlayerConfig configService)
        {
            _config = configService;
        }

        void IEcsInitSystem.Init()
        {
            var player = _world.NewEntity();
            ref var playerComponent = ref player.Get<PlayerComponent>();
            ref var movementComponent = ref player.Get<MovementComponent>();
            ref var lookComponent = ref player.Get<LookComponent>();

            var playerInstance = Object.Instantiate(_config.PlayerPrefab);
            playerInstance.transform.position = Vector3.zero;
            SetupPlayerComponent(ref playerComponent, playerInstance);
            SetupMovementComponent(ref movementComponent, playerInstance);
        }

        private void SetupPlayerComponent(ref PlayerComponent component, GameObject playerInstance)
        {
            component.Animator = playerInstance.GetComponent<Animator>();
            component.Hips = component.Animator.GetBoneTransform(HumanBodyBones.Hips);
        }

        private void SetupMovementComponent(ref MovementComponent component, GameObject playerInstance)
        {
            component.Speed = _config.Speed;
            component.Target = playerInstance.GetComponent<CharacterController>();
        }
    }
}
