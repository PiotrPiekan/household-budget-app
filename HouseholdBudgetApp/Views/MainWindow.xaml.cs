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

namespace HouseholdBudgetApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {

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

        private void OpenNewTransactionWindow(object sender, RoutedEventArgs e)
        {
            NewTransactionWindow window = new NewTransactionWindow();
            window.ShowDialog();
        }
    }
}
