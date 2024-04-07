using UnityEngine;
using UnityEngine.Rendering;

namespace ECSExample.Interfaces
{
    public interface ILightingConfig
    {
        public Quaternion Rotation { get; }
        public float Intensity { get; }
        public float IndirectMultiplier { get; }
        public LightShadows ShadowType { get; }
        public LightShadowResolution ShadowResolution { get; }
        public float ShadowStrength { get; }
        public float ShadowBias { get; }
        public float ShadowNormalBias { get; }
        public float ShadowNearPlane {  get; }
    }
}
