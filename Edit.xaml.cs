using Budget.Models;
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

namespace Budget
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private string _oldName;
        public Edit(string name, double amount)
        {
            InitializeComponent();
            txtNewName.Text = name;
            txtNewAmount.Text = amount.ToString("0.00");
            _oldName = name;
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            var main = (MainWindow)Application.Current.MainWindow;
            var model = main.Budgets.First(name => name.Name == _oldName);
            model.Name = txtNewName.Text;
            model.Amount = Convert.ToDouble(txtNewAmount.Text);
            main.RefreshList();
            this.Close();
        }
    }
}
