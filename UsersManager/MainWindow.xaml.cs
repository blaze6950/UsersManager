using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsersManager.Presenters;
using UsersManager.View;

namespace UsersManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewMainWindow
    {
        private IPresenterMainWindow _presenter;

        public MainWindow()
        {
            InitializeComponent();
            _presenter = new PresenterMainWindow(this);
        }

        private void MenuItemAddUser_OnClick(object sender, RoutedEventArgs e)
        {
            _presenter.AddUser();
        }

        private void MenuItemCategories_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Categories();
        }

        private void CheckBoxCategories_StateChanged(object sender, RoutedEventArgs e)
        {
            _presenter.CategoriesCheckBox_ChangeState();
        }

        public DataGrid MainDataGrid { get => DataGrid; set => DataGrid = value; }
        public ListBox CategoriesListBox { get => ListBoxCategories; set => ListBoxCategories = value; }
    }
}
