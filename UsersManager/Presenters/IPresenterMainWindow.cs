using System.Collections.Generic;
using System.Windows.Controls;

namespace UsersManager.Presenters
{
    public interface IPresenterMainWindow
    {
        void AddUser();
        void Categories();
        void CategoriesCheckBox_ChangeState(List<int> category);
        void AddCategoryColumn();
        void CommitChanges();
        void ChooseCategoryWindow(DataGridCellInfo cellInfo);
    }
}