using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Services
{
    public class MenuScope : BaseScope
    {
        [SerializeField] private MenuService _menuServiceInstance;


        private void Awake()
        {
            var sceneManager = new SceneManager();
            RegisterService<ISceneManager>(sceneManager);
            RegisterInstance(_menuServiceInstance).Initialize(sceneManager);
        }
    }
}
