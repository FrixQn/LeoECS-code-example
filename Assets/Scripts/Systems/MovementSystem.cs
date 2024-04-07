using ECSExample.Components;
using ECSExample.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<MovementComponent, LookComponent> _handlers;
        private IPlayerConfig _config;
        
        public MovementSystem(IPlayerConfig config)
        {
            _config = config;
        }
        
        void IEcsRunSystem.Run()
        {
            foreach(var handler in _handlers)
            {
                ref MovementComponent moveComponent = ref _handlers.Get1(handler);
                ref LookComponent lookComponent = ref _handlers.Get2(handler);

                moveComponent.Target.Move(CalculateMoveVelocity(ref moveComponent));
                moveComponent.Target.transform.rotation = Quaternion.Euler(0f, lookComponent.Direction.y, 0f);
            }
        }

        private Vector3 CalculateMoveVelocity(ref MovementComponent component)
        {
            return CalculateSpeed(ref component) * Time.deltaTime * ProjectDirection(ref component);
        }

        private Vector3 ProjectDirection(ref MovementComponent component)
        {
            return component.Target.transform.forward * component.Direction.z + component.Target.transform.right * component.Direction.x;
        }

        private float CalculateSpeed(ref MovementComponent component)
        {
            if (component.Direction.z > 0f && component.IsSprint)
            {
                return _config.SprintSpeed;
            }
            else
            {
                return _config.Speed;
            }
        }
    }
}
