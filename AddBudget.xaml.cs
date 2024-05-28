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
using System.Windows.Shapes;
using Budget.Models;

namespace Budget
{
    /// <summary>
    /// Interaction logic for AddBudget.xaml
    /// </summary>
    public partial class AddBudget : Window
    {
        public AddBudget()
        {
            InitializeComponent();
        }

        private void btnAddBudget_Click(object sender, RoutedEventArgs e)
        {
            var main = (MainWindow)Application.Current.MainWindow;
            BudgetModel model = new BudgetModel();
            model.Name = txtName.Text;
            model.Amount = Convert.ToDouble(txtAmount.Text);
            main.Budgets.Add(model);
            main.RefreshList();
            this.Close();
        }
    }
}
