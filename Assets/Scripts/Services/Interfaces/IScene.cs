using System;

namespace ECSExample.Interfaces
{
    public interface ISceneManager : IDisposable
    {
        public void LoadGameScene();
        public void LoadMenuScene();
    }
}
