using HouseholdBudgetApp.DataClasses;
using HouseholdBudgetApp.FileClasses;
using System.Windows;

namespace HouseholdBudgetApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account _account;
        public MainWindow()
        {
            _account = new Account();
            InitializeComponent();
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            _account = new Account();
        }

        private void Open(object sender, RoutedEventArgs e)
        {

        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTo(object sender, RoutedEventArgs e)
        {

        }

        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {

        }

        private void OpenTransactionWindow(object sender, RoutedEventArgs e)
        {
            TransactionWindow window = new TransactionWindow(_account);
            window.Owner = this;
            window.Show();
        }
    }
}
