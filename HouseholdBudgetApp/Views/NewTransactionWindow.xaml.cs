using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _tName = value;
                OnPropertyChanged("TName");
            }
        }

        private string _tCategory;
        public string TCategory{ get; set; }

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
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(
                string.IsNullOrEmpty(TName)
                || TAmount <= 0
            );
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
