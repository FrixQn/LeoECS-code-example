using ECSExample.Components;
using ECSExample.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class SimpleGravitySystem : IEcsRunSystem
    {
        private readonly IPhysicsConfig _config;
        EcsFilter<MovementComponent> _filter;

        public SimpleGravitySystem(IPhysicsConfig config)
        {
            _config = config;
        }

        void IEcsRunSystem.Run()
        {
            foreach (var componentIndex in _filter)
            {
                ref MovementComponent component = ref _filter.Get1(componentIndex);
                if (!component.Target.isGrounded)
                {
                    component.Target.Move(_config.Gravity * Time.fixedDeltaTime);
                }
            }
        }
    }
}
