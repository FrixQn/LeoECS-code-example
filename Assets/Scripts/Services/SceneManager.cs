using ECSExample.Interfaces;
using System;

namespace ECSExample.Services
{
    public class SceneManager : ISceneManager
    {
        private const int MENU_SCENE_INDEX = 0;
        private const int GAME_SCENE_INDEX = 1;

        private int _currentSceneIndex = 0;

        public SceneManager()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            _currentSceneIndex = scene.buildIndex;
        }

        void ISceneManager.LoadGameScene()
        {
            LoadScene(GAME_SCENE_INDEX);
        }

        void ISceneManager.LoadMenuScene()
        {
            LoadScene(MENU_SCENE_INDEX);
        }

        private void LoadScene(int sceneIndex)
        {
            if (_currentSceneIndex != sceneIndex)
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
