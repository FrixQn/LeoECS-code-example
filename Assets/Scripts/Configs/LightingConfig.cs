using ECSExample.Interfaces;
using UnityEngine;
using UnityEngine.Rendering;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(LightingConfig), menuName = "Project/" + nameof(LightingSettings))]
    internal class LightingConfig : ScriptableObject , ILightingConfig
    {
        [SerializeField] private Quaternion _rotation;
        [SerializeField] private float _intensity = 1f;
        [SerializeField] private float _indirectMultiplier = 1f;
        [Header("Shadow settings")]
        [SerializeField] private LightShadows _shadowType;
        [SerializeField, Range(0f, 1f)] private float _strength = 1f;
        [SerializeField] private LightShadowResolution _resolution;
        [SerializeField, Range(0f, 2f)] private float _bias;
        [SerializeField, Range(0f, 3f)] private float _normanlBias;
        [SerializeField, Range(0.1f, 10f)] private float _neraPlane = 0.1f;

        Quaternion ILightingConfig.Rotation => _rotation;
        float ILightingConfig.Intensity => _intensity;
        float ILightingConfig.IndirectMultiplier => _indirectMultiplier;
        LightShadows ILightingConfig.ShadowType => _shadowType;
        LightShadowResolution ILightingConfig.ShadowResolution => _resolution;
        float ILightingConfig.ShadowStrength => _strength;
        float ILightingConfig.ShadowBias => _bias;
        float ILightingConfig.ShadowNormalBias => _normanlBias;
        float ILightingConfig.ShadowNearPlane => _neraPlane;
    }
}
