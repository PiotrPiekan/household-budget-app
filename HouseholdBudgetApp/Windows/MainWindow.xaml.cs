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
        public Account account = new Account("JaXD");
        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            SaldoBox.Text = account.saldo.ToString() + " zł";
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {

        }

        private void Open(object sender, RoutedEventArgs e) //Wczytaj?
        {
            IO io = new IO();
            account = io.LoadData("test.txt");
            DisplayDataInGrid();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            IO io = new IO();
            io.SaveData("test2.txt", account);
        }

        private void SaveTo(object sender, RoutedEventArgs e)
        {

        }

        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {

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

            foreach (SingleTransaction expense in MainWindow.mainWindow.account.expense)
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


            foreach (SingleTransaction income in MainWindow.mainWindow.account.income)
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
