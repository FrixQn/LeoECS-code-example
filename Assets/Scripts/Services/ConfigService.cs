using ECSExample.Configs;
using ECSExample.Interfaces;

namespace ECSExample.Services
{
    public class ConfigService : IConfigService
    {
        private readonly ConfigsContainer _container;
        public ConfigService(ConfigsContainer container)
        {
            _container = container;
        }

        IPlayerConfig IConfigService.PlayerConfig => _container.PlayerConfig;
        ICameraConfig IConfigService.CameraConfig => _container.CameraConfig;
        IPhysicsConfig IConfigService.PhysicsConfig => _container.PhysicsConfig;
        ILightingConfig IConfigService.LightingConfig => _container.LightingConfig;
        IBalloonsSystemConfig IConfigService.BalloonsSystemConfig => _container.BalloonsSystemConfig;
    }
}
