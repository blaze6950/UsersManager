using UsersManager.View;
using UsersManager.Model;

namespace UsersManager.Presenters
{
    public class PresenterMainWindow : IPresenterMainWindow
    {
        private IViewMainWindow _view;
        private Model.Model _model;

        public PresenterMainWindow(IViewMainWindow view)
        {
            _view = view;
            _model = new Model.Model();
            InitializeView();
        }

        private void InitializeView()
        {
            
        }

        public void AddUser()
        {
            
        }

        public void Categories()
        {

        }

        public void CategoriesCheckBox_ChangeState()
        {

        }
    }
}