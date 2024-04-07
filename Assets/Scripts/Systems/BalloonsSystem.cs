using ECSExample.Components;
using ECSExample.Extensions;
using ECSExample.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class BalloonsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IBalloonsSystemConfig _config;
        private EcsWorld _world;
        private EcsFilter<BalloonComponent> _filterBallons;
        private EcsFilter<PlayerComponent, MovementComponent> _filterPlayer;

        public BalloonsSystem(IBalloonsSystemConfig config) 
        { 
            _config = config;
        }

        void IEcsInitSystem.Init()
        {
            CreateNewBalloon();
        }

        void IEcsRunSystem.Run()
        {
            bool createNewBalloon = false;
            foreach(var index in _filterBallons)
            {
                bool isDestroyed = false;
                ref BalloonComponent component = ref _filterBallons.Get1(index);

                if (component.Direction == Vector3.zero)
                {
                    component.Direction = Random.Range(0, 2) == 0 ? Vector3.down : Vector3.up;
                }
                else
                {
                    if (component.Direction == Vector3.up && component.Transform.position.y >= component.TopPositionLimit.y)
                    {
                        component.Direction = Vector3.down;
                    }

                    if (component.Direction == Vector3.down && component.Transform.position.y <= component.BottomPositionLimit.y)
                    {
                        component.Direction = Vector3.up;
                    }
                }

                foreach(var playerIndex in _filterPlayer)
                {
                    ref PlayerComponent playerComponent = ref _filterPlayer.Get1(playerIndex);
                    ref MovementComponent movementComponent = ref _filterPlayer.Get2(playerIndex);

                    if (movementComponent.Target.bounds.Intersects(component.Renderer.bounds))
                    {
                        DestroyBalloon(ref _filterBallons.GetEntity(index), ref component);
                        createNewBalloon = true;
                        isDestroyed = true;
                        break;
                    }
                }

                if (!isDestroyed)
                {
                    component.Transform.position += _config.FloatingSpeed * Time.deltaTime * component.Direction;
                }
            }

            if (createNewBalloon)
            {
                CreateNewBalloon();
            }
        }

        private void DestroyBalloon(ref EcsEntity entity, ref BalloonComponent component)
        {
            Object.Destroy(component.Transform.gameObject);
            entity.Destroy();
        }

        private void CreateNewBalloon()
        {
            var entity = _world.NewEntity();
            ref BalloonComponent component = ref entity.Get<BalloonComponent>();

            var balloonInstance = Object.Instantiate(_config.Prefabs[Random.Range(0, _config.Prefabs.Length)]);
            balloonInstance.transform.position = _config.SpawnExtents.RandomPoint(_config.BoundsCenter); 
            component.Transform = balloonInstance.transform;
            component.Renderer = component.Transform.GetComponent<Renderer>();
            component.TopPositionLimit = balloonInstance.transform.position + Vector3.up * _config.FloatingRange;
            component.BottomPositionLimit = balloonInstance.transform.position + Vector3.down * _config.FloatingRange;
        }
    }
}
