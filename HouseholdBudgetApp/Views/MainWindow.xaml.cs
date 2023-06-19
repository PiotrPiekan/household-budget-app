using System.Collections.Generic;
using System.Windows;
using HouseholdBudgetApp.DataClasses;
using HouseholdBudgetApp.FileClasses;

namespace HouseholdBudgetApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Account MyAccount = new Account("Student Biedak");
        public static MainWindow mainWindow;
        private IO _io = new IO();

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            SaldoBox.Text = MyAccount.saldo.ToString() + " zł";
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            MyAccount = new Account("Student Biedak");
            _io = new IO();
            DisplayDataInGrid();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            if (_io.SelectFile(false))
            {
                MyAccount = _io.LoadData();
                DisplayDataInGrid();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            bool selected = true;
            if (string.IsNullOrEmpty(_io.FilePath))
                selected = _io.SelectFile(true);
            if (selected)
                _io.SaveData(MyAccount);
        }

        private void SaveTo(object sender, RoutedEventArgs e)
        {
            if (_io.SelectFile(true))
                _io.SaveData(MyAccount);
        }

        private void OpenNewTransactionWindow(object sender, RoutedEventArgs e)
        {
            NewTransactionWindow window = new NewTransactionWindow();
            window.Owner = this;
            window.ShowDialog();
          
        }

        public void DisplayDataInGrid()
        {
            List<DisplayData> transactions = new List<DisplayData>();

            foreach (SingleTransaction expense in MainWindow.mainWindow.MyAccount.expense)
            {

                DisplayData data = new DisplayData();
                data.Nazwa = expense.getName();
                data.Kwota = expense.getAmount().ToString() + " zł";
                data.Data = expense.getDate().ToShortDateString();
                data.Kategoria = expense.getCategories();
                if (expense.info.isConstant == true)
                {
                    data.Stałe = "tak";     //dodac informacje co ile itd;
                }
                else
                {
                    data.Stałe = "nie";
                }

                transactions.Add(data);
            }


            foreach (SingleTransaction income in MainWindow.mainWindow.MyAccount.income)
            {
                DisplayData data = new DisplayData();
                data.Nazwa = income.getName();
                data.Kwota = "+" + income.getAmount().ToString() + " zł";
                data.Data = income.getDate().ToShortDateString();
                data.Kategoria = income.getCategories();
                if (income.info.isConstant == true)
                {
                    data.Stałe = "tak";     //dodac informacje co ile itd;
                }
                else
                {
                    data.Stałe = "nie";
                }

                transactions.Add(data);
            }

            MainWindow.mainWindow.DataDisplayGrid.ItemsSource = transactions;
        }
    }

    public class DisplayData
    {
        public string Nazwa { set; get; }
        public string Kwota { set; get; }
        public string Data { set; get; }
        public string Kategoria { set; get; }
        public string Stałe { set; get; }
    }
}
