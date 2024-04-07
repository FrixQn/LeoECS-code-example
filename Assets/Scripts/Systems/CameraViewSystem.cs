using ECSExample.Components;
using ECSExample.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSExample.Systems
{
    public class CameraViewSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly ICameraConfig _config;
        private EcsFilter<PlayerComponent, LookComponent> _filter;

        public CameraViewSystem(ICameraConfig cameraConfig)
        {
            _config = cameraConfig;
        }

        void IEcsInitSystem.Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            var goInstance = new GameObject("Camera", new System.Type[] { typeof(Camera) });
            var camera = goInstance.GetComponent<Camera>();
            camera.fieldOfView = _config.FOV;
            camera.nearClipPlane = _config.NearPlaneClipping;
            camera.farClipPlane = _config.FarPlaneClipping;

            foreach (var componentIndex in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(componentIndex);
                playerComponent.Camera = camera;
            }
        }

        void IEcsRunSystem.Run()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _config.LookSensivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _config.LookSensivity;

            foreach (var componentIndex in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(componentIndex);
                ref LookComponent lookComponent = ref _filter.Get2(componentIndex);
                lookComponent.Direction = CalculateDirection(ref lookComponent, mouseX, mouseY);
                playerComponent.Camera.transform.SetPositionAndRotation(
                    playerComponent.Hips.position +
                    playerComponent.Hips.right * _config.Offset.x +
                    playerComponent.Hips.up * _config.Offset.y +
                    playerComponent.Hips.forward * _config.Offset.z,
                    Quaternion.Euler(lookComponent.Direction.x, lookComponent.Direction.y, 0f));
            }
        }

        private Vector2 CalculateDirection(ref LookComponent component, float mouseX, float mouseY)
        {
            return new Vector2(Mathf.Clamp(component.Direction.x - mouseY, -90f, 90f), component.Direction.y + mouseX);
        }
    }
}
