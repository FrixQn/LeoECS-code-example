using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "Project/" + nameof(CameraConfig))]
    internal class CameraConfig : ScriptableObject, ICameraConfig
    {
        private const float SENSIVITY_VALUE_MULTIPLIER = 100f;
        [SerializeField, Range(60f, 90f)] private float _fov = 60f;
        [SerializeField] private Vector3 _offset;
        [SerializeField, Range(0.5f, 10f)] private float _sensivity;
        [SerializeField, Range(0.01f, 1f)] private float _nearPlaneClipping = 0.1f;
        [SerializeField] private float _farPlaneClipping = 100f;

        float ICameraConfig.FOV => _fov;
        Vector3 ICameraConfig.Offset => _offset;
        float ICameraConfig.LookSensivity => _sensivity * SENSIVITY_VALUE_MULTIPLIER;
        float ICameraConfig.NearPlaneClipping => _nearPlaneClipping;
        float ICameraConfig.FarPlaneClipping => _farPlaneClipping;
    }
}
