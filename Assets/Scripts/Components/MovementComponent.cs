using UnityEngine;

namespace ECSExample.Components
{
    public struct MovementComponent 
    {
        public CharacterController Target;
        public float Speed;
        public Vector3 Direction;
        public bool IsSprint;
    }
}
