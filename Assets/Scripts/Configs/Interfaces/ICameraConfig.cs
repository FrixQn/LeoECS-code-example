using UnityEngine;

namespace ECSExample.Interfaces
{
    public interface ICameraConfig
    {
        public float FOV { get; }
        public Vector3 Offset { get; }
        public float LookSensivity { get; }
        public float NearPlaneClipping { get; }
        public float FarPlaneClipping { get; }
    }
}
