using ECSExample.Interfaces;

namespace ECSExample.Presenters
{
    public class MenuPresenter : IMenuPresenter
    {
        private IMenuView _view;
        private IMenuModel _model;

        public MenuPresenter(IMenuModel model, IMenuView view) 
        { 
            _model = model;
            _view = view;
            _view.Initialize(this);
        }

        void IMenuPresenter.OnPlayButtonClicked()
        {
            _model.StartGame();
        }
    }
}
