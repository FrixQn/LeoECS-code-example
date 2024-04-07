using UnityEngine;

namespace ECSExample.Components
{
    public struct PlayerComponent
    {
        public Animator Animator;
        public Transform Hips;
        public Camera Camera;
        public bool IsPunch;
    }
}
