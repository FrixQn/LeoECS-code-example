using ECSExample.Interfaces;

namespace ECSExample.Models
{
    public class MenuModel : IMenuModel
    {
        private ISceneManager _sceneManager;
        public MenuModel(ISceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        void IMenuModel.StartGame()
        {
            _sceneManager.LoadGameScene();
        }
    }
}
