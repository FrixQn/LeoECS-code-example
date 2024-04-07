using ECSExample.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ECSExample.UI
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private Button _playBtn;
        private IMenuPresenter _presenter;

        void IMenuView.Initialize(IMenuPresenter menuPresenter)
        {
            _presenter = menuPresenter;

            if (_playBtn == null)
                throw new NullReferenceException();

            Subscribe();
        }

        private void Subscribe()
        {
            _playBtn.onClick.AddListener(OnClicked);
        }
        
        private void OnClicked()
        {
            _presenter.OnPlayButtonClicked();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (_playBtn != null)
                _playBtn.onClick.RemoveAllListeners();
        }
    }
}
