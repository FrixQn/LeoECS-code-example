using UnityEngine;

namespace ECSExample.Interfaces
{
    public interface IBalloonsSystemConfig
    {
        public GameObject[] Prefabs { get; }
        public float FloatingSpeed { get; }
        public float FloatingRange { get; }
        public Vector3 BoundsCenter { get; }
        public Vector3 SpawnExtents { get; }
    }
}
