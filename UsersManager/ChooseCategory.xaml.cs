using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;

namespace UsersManager
{
    /// <summary>
    /// Interaction logic for ChooseCategory.xaml
    /// </summary>
    public partial class ChooseCategory : Window
    {
        private DataGridCellInfo _cellInfo;
        private IEnumerable<Category> _categories;
        public ChooseCategory(DataGridCellInfo cellInfo, IEnumerable<Category> categories)
        {
            InitializeComponent();

            _cellInfo = cellInfo;
            _categories = categories;

            int? selectedCategory = 0;
            
            if (((DataRowView)cellInfo.Item).Row.ItemArray[4] != null)
            {
                selectedCategory = (int?)((DataRowView)cellInfo.Item).Row.ItemArray[4];
            }
            RadioButton radioButton;
            foreach (var category in categories)
            {
                radioButton = new RadioButton();
                radioButton.Content = category.Name;
                if (selectedCategory != null && category.Id == selectedCategory)
                {
                    radioButton.IsChecked = true;
                }
                StackPanel.Children.Add(radioButton);
            }
            
        }

        private void ChooseCategory_OnClosing(object sender, CancelEventArgs e)
        {
            Category res = null;
            foreach (RadioButton radioButton in StackPanel.Children)
            {
                if (radioButton.IsChecked != null && (bool) radioButton.IsChecked)
                {
                    res = _categories.Single(c => c.Name.Equals(radioButton.Content));
                }
            }
            ((DataRowView) _cellInfo.Item).Row[4] = res.Id;

            //((DataRowView) _cellInfo.Item).Row.ItemArray[4] = res.Id;
        }
    }
}
