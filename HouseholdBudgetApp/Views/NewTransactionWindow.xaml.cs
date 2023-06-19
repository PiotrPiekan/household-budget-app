using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HouseholdBudgetApp.DataClasses;

namespace HouseholdBudgetApp.Views
{
    /// <summary>
    /// Interaction logic for NewTransactionWindow.xaml
    /// </summary>
    public partial class NewTransactionWindow : Window, INotifyPropertyChanged
    {
        public NewTransactionWindow()
        {
            InitializeComponent();
            DataContext = this;
            Title = "Dodaj transakcję";
            _tName = "NazwaTransakcji";
            _tAmount = 100.0;
            _tDate = DateTime.Today;
        }


        private string _tName;
        public string TName
        {
            get
            {
                return _tName;
            }
            set
            {
                _tName = value;
                OnPropertyChanged("TName");
            }
        }

        private double _tAmount;
        public double TAmount
        {
            get
            {
                return _tAmount;
            }
            set
            {
                _tAmount = value;
                OnPropertyChanged("TAmount");
            }
        }

        private DateTime _tDate;
        public DateTime TDate
        {
            get
            {
                return _tDate;
            }
            set
            {
                _tDate = value;
                OnPropertyChanged("TDate");
            }
        }


        private int _tRepeatInterval;
        public int TRepeatInterval
        {
            get
            {
                return _tRepeatInterval;
            }
            set
            {
                _tRepeatInterval = value;
                OnPropertyChanged("TRepeatInterval");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Confirm
            //DialogResult = true;
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(
                string.IsNullOrEmpty(TName)
                || TAmount <= 0
                || false
            );
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        void ClosingNewTransactionWindow(object sender, CancelEventArgs e)
        {
            MainWindow.mainWindow.DisplayDataInGrid();
            MainWindow.mainWindow.SaldoBox.Text = MainWindow.mainWindow.MyAccount.saldo.ToString() + " zł";
            //MainWindow.mainWindow.account.CheckNextConstantTransactions(); //działało i nie działa :|
        }

        private void SaveAndAdd(object sender, RoutedEventArgs e)
        {
            string s = Amount.Text.ToString();
            string z = s.Remove(s.IndexOf(' '));

            float amountValue = float.Parse(z);
            if ((bool)ExpenseButton.IsChecked) amountValue *= (-1);

            SingleTransaction transaction = new SingleTransaction(Name.Text, amountValue, Date.SelectedDate.Value.Date, Comb.Text);
            if ((bool)IsRepeat.IsChecked)
            {
                transaction.info.isConstant = true;
                transaction.info.timeSpan = int.Parse(timeSpanBox.Text);
                if (TypeOfTime.Text.Equals("Tydzień")) transaction.info.timeSpan *= 7;
                else if (TypeOfTime.Text.Equals("Miesiąc")) transaction.info.timeSpan *= 30;
                transaction.info.howMany = int.Parse(HowMany.Text);
            }
            else transaction.info.isConstant = false;

            if ((bool)ExpenseButton.IsChecked)
            {
                MainWindow.mainWindow.MyAccount.setExpense(transaction);
            }
            if ((bool)IncomeButton.IsChecked)
            {
                MainWindow.mainWindow.MyAccount.setIncome(transaction);
            }
            Close();
        }
    }

    public class ViewboxPanel : StackPanel
    {
        private double scale;

        protected override Size MeasureOverride(Size availableSize)
        {
            double height = 0;
            Size unlimitedSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            foreach (UIElement child in Children)
            {
                child.Measure(unlimitedSize);
                height += child.DesiredSize.Height;
            }
            scale = availableSize.Height / height;

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Transform scaleTransform = new ScaleTransform(scale, scale);
            double height = 0;
            foreach (UIElement child in Children)
            {
                child.RenderTransform = scaleTransform;
                child.Arrange(new Rect(new Point(0, scale * height), new Size(finalSize.Width / scale, child.DesiredSize.Height)));
                height += child.DesiredSize.Height;
            }

            return finalSize;
        }
    }
}
