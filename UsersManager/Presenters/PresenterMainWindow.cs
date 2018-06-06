using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
            _view.MainDataGrid.ItemsSource = _model.GetUsers().DefaultView;//.AsDataView();
            var categories = _model.GetCategories().Select();
            var categoriesList = (from c in categories
                                  select new Category{ Name = (string)c.ItemArray[1], Id = (int)c.ItemArray[0] });

            _view.CategoriesListBox.ItemsSource = categoriesList;

            //_view.MainDataGrid.DataContext = _model.GetUsers();
            //_view.CategoriesListBox.ItemsSource = _model.GetCategories();
        }

        public void AddUser()
        {
            
        }

        public void Categories()
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.CategoriesDataGrid.ItemsSource = _model.GetCategories().DefaultView;
            categoriesWindow.ShowDialog();
            _model.RefreshData();
            var categories = _model.GetCategories().Select();
            var categoriesList = (from c in categories
                select new { Name = c.ItemArray[1] });

            _view.CategoriesListBox.ItemsSource = categoriesList;
        }

        public void CategoriesCheckBox_ChangeState(List<int> category)
        {
            _view.MainDataGrid.ItemsSource = _model.GetUserCategory(category).DefaultView;
        }

        public void AddCategoryColumn()
        {
            //DataGridComboBoxColumn column = new DataGridComboBoxColumn();
            //column.ItemsSource = _model.GetCategories();
            //column.Header = "Category";
            //column.TextBinding = new Binding("idCategory");
            //_view.MainDataGrid.Columns.Add(column);
        }

        public void CommitChanges()
        {
            _model.Dispose();
        }
    }
}