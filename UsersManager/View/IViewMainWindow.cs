using System.Windows.Controls;

namespace UsersManager.View
{
    public interface IViewMainWindow
    {
        DataGrid MainDataGrid { get; set; }
        ListBox CategoriesListBox { get; set; }
    }
}