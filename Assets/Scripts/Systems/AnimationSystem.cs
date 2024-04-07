using ECSExample.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class AnimationSystem : IEcsRunSystem, IEcsInitSystem
    {
        private const float SPRINT_VALUE_MULTIPLIER = 2;
        private const string PUNCH_PARAMATER = "Punch";
        private const string VERTICAL_DIR_PARAMETER = "VerticalDir";
        private const string HORIZONTAL_DIR_PARAMETER = "HorizontalDir";
        private EcsFilter<PlayerComponent, MovementComponent> _filter;
        private int _vertialDirParamHash;
        private int _horizontalDirParamHash;
        private int _punchParamHash;
        void IEcsInitSystem.Init()
        {
            _vertialDirParamHash = Animator.StringToHash(VERTICAL_DIR_PARAMETER);
            _horizontalDirParamHash = Animator.StringToHash(HORIZONTAL_DIR_PARAMETER);
            _punchParamHash = Animator.StringToHash(PUNCH_PARAMATER);
        }

        void IEcsRunSystem.Run()
        {
            foreach(var component in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(component);

                ref PlayerComponent playerComponent = ref _filter.Get1(component);
                ref MovementComponent movementComponent = ref _filter.Get2(component);
                ref Animator animator = ref playerComponent.Animator;

                if (playerComponent.IsPunch)
                {
                    animator.SetTrigger(_punchParamHash);
                }

                animator.SetFloat(_vertialDirParamHash , movementComponent.IsSprint ? movementComponent.Direction.z * SPRINT_VALUE_MULTIPLIER : movementComponent.Direction.z);
                animator.SetFloat(_horizontalDirParamHash, movementComponent.IsSprint ? movementComponent.Direction.x * SPRINT_VALUE_MULTIPLIER : movementComponent.Direction.x);
            }
        }
    }
}
