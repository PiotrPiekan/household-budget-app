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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// zrobic formularz, zrobic maina, zrobic zapis do pliku
    /// https://stackoverflow.com/questions/33280097/disable-a-button-if-either-of-the-two-textboxes-are-empty !!!!!!!!!!
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpApp();
            //Konto konto = new Konto("Jan Pawel", 21.37f); //wywalić to do jakiegoś maina
            
        }

        //Założenia początkowe trakcie startu aplikacji
        private void SetUpApp() 
        {
            //throw new NotImplementedException();
            //tu jakies zalozenia poczatkowe
        }

        private void DodajWplyw(object sender, RoutedEventArgs e)
        {
           OknoDodajTransakcje okno= new OknoDodajTransakcje();
           okno.Show();
            okno.Title = "Dodaj nowy wplyw";
           
        }

        private void DodajWydatek(object sender, RoutedEventArgs e)
        {
            OknoDodajTransakcje okno = new OknoDodajTransakcje();
            okno.Show();
            okno.Title = "Dodaj nowy wydatek";
        }

        private void ZapiszDane(object sender, RoutedEventArgs e)
        {

        }

        private void WczytajDane(object sender, RoutedEventArgs e)
        {


        }
    }
}
