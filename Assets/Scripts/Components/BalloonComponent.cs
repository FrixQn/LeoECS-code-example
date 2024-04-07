using UnityEngine;

namespace ECSExample.Components
{
    public struct BalloonComponent
    {
        public Transform Transform;
        public Renderer Renderer;
        public Vector3 TopPositionLimit;
        public Vector3 BottomPositionLimit;
        public Vector3 Direction;
    }
}
