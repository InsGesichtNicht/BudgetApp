using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Budget.Models;

namespace Budget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BudgetModel> Budgets = new List<BudgetModel>();
        public MainWindow()
        {
            if (!File.Exists("Budget.dat"))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("budget.dat");
                    sw.WriteLine("Rent");
                    sw.WriteLine("0.00");
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Failed to created budget file.", "Error");
                }
            }

            StreamReader sr = new StreamReader("budget.dat");
            try
            {
                while (!sr.EndOfStream)
                {
                    BudgetModel model = new BudgetModel();
                    model.Name = sr.ReadLine();
                    model.Amount = Convert.ToDouble(sr.ReadLine());
                    Budgets.Add(model);
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("Failed to get budget list.", "Error");
            }

            InitializeComponent();

            RefreshList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBudget Add = new AddBudget();
            Add.Show();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Budgets.Remove(Budgets[lstBxBudgetList.SelectedIndex]);
            RefreshList();
        }

        public void RefreshList()
        {
            double total = 0;
            lstBxBudgetList.Items.Clear();
            foreach (var model in Budgets)
            {
                lstBxBudgetList.Items.Add(String.Format("{0}: ${1}", model.Name, model.Amount.ToString("0.00")));
                total += model.Amount;
            }
            lblTotal.Content = String.Format("Total:\n${0}", total.ToString("0.00"));
            lstBxBudgetList.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("budget.dat");
                foreach (var model in Budgets)
                {
                    sw.WriteLine(model.Name);
                    sw.WriteLine(model.Amount.ToString());
                }
                sw.Close();

                MessageBox.Show("Saved.", "Info");
            }
            catch
            {
                MessageBox.Show("Failed to save.", "Error");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit editor = new Edit(Budgets[lstBxBudgetList.SelectedIndex].Name, Budgets[lstBxBudgetList.SelectedIndex].Amount);
            editor.Show();
        }
    }
}