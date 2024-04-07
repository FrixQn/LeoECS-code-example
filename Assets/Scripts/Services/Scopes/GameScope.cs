using ECSExample.Configs;
using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Services 
{
    public class GameScope : BaseScope
    {
        [SerializeField] private ConfigsContainer _container;
        [SerializeField] private GameEntryPoint _gameEntryPoint;
        [SerializeField] private Light _mainLight;

        private void Awake()
        {
            ConfigService configService = new ConfigService(_container);
            RegisterService<IConfigService>(configService);

            _gameEntryPoint.Initialize(GetServiceByType<IConfigService>());
            SetupMainLight(_container.LightingConfig);
        }

        private void SetupMainLight(ILightingConfig lightingConfig)
        {
            _mainLight.transform.rotation = lightingConfig.Rotation;
            _mainLight.intensity = lightingConfig.Intensity;
            _mainLight.bounceIntensity = lightingConfig.IndirectMultiplier;
            _mainLight.shadows = lightingConfig.ShadowType;
            _mainLight.shadowStrength = lightingConfig.ShadowStrength;
            _mainLight.shadowResolution = lightingConfig.ShadowResolution;
            _mainLight.shadowNearPlane = lightingConfig.ShadowNearPlane;
            _mainLight.shadowBias = lightingConfig.ShadowBias;
            _mainLight.shadowNormalBias = lightingConfig.ShadowNormalBias;
        }
    }
}
