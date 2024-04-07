namespace ECSExample.Interfaces
{
    public interface IConfigService
    {
        public IPlayerConfig PlayerConfig { get; }
        public ICameraConfig CameraConfig { get; }
        public IPhysicsConfig PhysicsConfig { get; }
        public ILightingConfig LightingConfig { get; }
        public IBalloonsSystemConfig BalloonsSystemConfig { get; }
    }
}
