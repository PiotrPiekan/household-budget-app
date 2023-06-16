using HouseholdBudgetApp.DataClasses;
using HouseholdBudgetApp.CustomElements;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using HouseholdBudgetApp.Exceptions;

namespace HouseholdBudgetApp.Views
{
    /// <summary>
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window, INotifyPropertyChanged
    {
        private readonly Account _account;
        public ObservableCollection<Category> CategoryList { get; }

        private string _tName;
        private int _tCategory;
        private double _tAmount;
        private bool _tIsExpense;
        private DateTime? _tDate;
        private bool _tIsRepeating;
        private short _tRepeatIntervalAmount;
        private short _tRepeatIntervalType;
        private short _tRepeatCount;

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
        public int TCategory
        {
            get
            {
                return _tCategory;
            }
            set
            {
                _tCategory = value;
                OnPropertyChanged("TCategory");
            }
        }
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
        public bool TIsExpense
        {
            get
            {
                return _tIsExpense;
            }
            set
            {
                _tIsExpense = value;
                OnPropertyChanged("TIsExpense");
            }
        }
        public DateTime? TDate
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
        public bool TIsRepeating
        {
            get
            {
                return _tIsRepeating;
            }
            set
            {
                _tIsRepeating = value;
                OnPropertyChanged("TIsRepeating");
            }
        }
        public short TRepeatIntervalAmount
        {
            get
            {
                return _tRepeatIntervalAmount;
            }
            set
            {
                _tRepeatIntervalAmount = value;
                OnPropertyChanged("TRepeatIntervalAmount");
            }
        }
        public short TRepeatIntervalType
        {
            get
            {
                return _tRepeatIntervalType;
            }
            set
            {
                _tRepeatIntervalType = value;
                OnPropertyChanged("TRepeatIntervalType");
            }
        } // NIE CZYTA WARTOŚCI
        public short TRepeatCount
        {
            get
            {
                return _tRepeatCount;
            }
            set
            {
                _tRepeatCount = value;
                OnPropertyChanged("TRepeatCount");
            }
        }

        public TransactionWindow(Account account)
        {
            InitializeComponent();

            DataContext = this;
            Title = "Dodaj transakcję";

            _account = account;
            CategoryList = _account.CategoryList;

            _tName = "NazwaTransakcji";
            _tAmount = 100.0;
            _tCategory = 0;
            _tIsExpense = true;
            _tDate = DateTime.Today;
            _tIsRepeating = false;
            _tRepeatIntervalAmount = 1;
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
            Transaction newTransaction = new Transaction(
                _tName,
                _tCategory,
                _tAmount,
                _tIsExpense,
                _tDate ?? new DateTime(),
                _tIsRepeating,
                _tRepeatIntervalAmount,
                //_tRepeatIntervalType,
                1,
                _tRepeatCount
                );
            try
            {
                _account.AddTransaction(newTransaction);
                Close();
            }
            catch (ExistingTransactionException)
            {
                string msg = "Już istnieje transakcja o podanej nazwie.";
                MessageBox.Show(msg, "Nazwa zajęta", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(
                string.IsNullOrEmpty(_tName)
                || _tAmount <= 0
                || _tCategory <= 0
                || _tDate == null
                || (_tIsRepeating && _tRepeatIntervalAmount <= 0)
                );
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
