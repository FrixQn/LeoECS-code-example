using ECSExample.Interfaces;
using ECSExample.Models;
using ECSExample.Presenters;
using ECSExample.UI;
using System;
using UnityEngine;

namespace ECSExample.Services
{
    public class MenuService : MonoBehaviour
    {
        [SerializeField] private MenuView _viewPrefab;
        private MenuModel _model;
        private MenuPresenter _presenter;

        public void Initialize(ISceneManager sceneManager)
        {
            if (_viewPrefab == null)
                throw new NullReferenceException();

            var view = Instantiate(_viewPrefab);
            _model = new MenuModel(sceneManager);
            _presenter = new MenuPresenter(_model, view);
        }
    }
}
