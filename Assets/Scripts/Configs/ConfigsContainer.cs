using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(ConfigsContainer), menuName = "Project/" + nameof(ConfigsContainer))]
    public class ConfigsContainer : ScriptableObject
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private PhysicsConfig _physicsConfig;
        [SerializeField] private LightingConfig _lightingConfig;
        [SerializeField] private BalloonsSystemConfig _ballonsSystemConfig;

        public IPlayerConfig PlayerConfig => _playerConfig;
        public ICameraConfig CameraConfig => _cameraConfig;
        public IPhysicsConfig PhysicsConfig => _physicsConfig;
        public ILightingConfig LightingConfig => _lightingConfig;
        public IBalloonsSystemConfig BalloonsSystemConfig => _ballonsSystemConfig;
    }
}
