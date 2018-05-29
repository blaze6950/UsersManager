using System.Linq;
using System.Windows.Controls;
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
            _view.MainDataGrid.DataContext = _model.GetUsers();
            var categories = _model.GetCategories().Select();
            var categoriesList = (from c in categories
                select new {Name = c.ItemArray[1]});

            _view.CategoriesListBox.ItemsSource = categoriesList;
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