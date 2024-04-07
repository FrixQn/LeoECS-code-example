using ECSExample.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, MovementComponent> _filter;
        private Vector2 _direction;
        private Vector3 _projectedDirection;
        void IEcsRunSystem.Run()
        {
            ReadInput();

            foreach (var componentIndex in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(componentIndex);
                ref MovementComponent movementComponent = ref _filter.Get2(componentIndex);

                playerComponent.IsPunch = Input.GetKeyDown(KeyCode.Mouse0);
                movementComponent.IsSprint = Input.GetKey(KeyCode.LeftShift);
                movementComponent.Direction = _projectedDirection;
            }
        }

        private void ReadInput()
        {
            _direction = Vector2.Lerp(_direction, Vector2.zero, Time.deltaTime * 10f);
            _direction.y = ReadVerticalInput(_direction.y);
            _direction.x = ReadHorizontalInput(_direction.x);
            _projectedDirection = new Vector3(_direction.x, 0f, _direction.y);
        }

        private float ReadVerticalInput(float currentValue)
        {
            return Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : currentValue;
        }

        private float ReadHorizontalInput(float currentValue)
        {
            return Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : currentValue;
        }
    }
}
