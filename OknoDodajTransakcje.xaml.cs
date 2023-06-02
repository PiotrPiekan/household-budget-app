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
using System.Text.RegularExpressions;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajTransakcje.xaml
    /// </summary>
    public partial class OknoDodajTransakcje : Window
    {
        public OknoDodajTransakcje()
        {
            InitializeComponent();
            CyklBox.IsEnabled = false;
            DodajTransakcjeButton.IsEnabled = false;


            if (KwotaBox.Text.Length > 0 && TytulBox.Text.Length > 0 && DataBox.Text.Length > 0)
            {
                DodajTransakcjeButton.IsEnabled = true;
            }
        }


        
        //nie wiem po co tu to dałam XD
        private void WczytajWartosci()
        {
         
        }

        private void CzyLiczba(object sender, TextCompositionEventArgs e) //DO ZROBIENIA NIE WIEM CZEMU MI NIE DZIALA
        {
            Regex regex = new Regex(@"[^0-9]+");
            if( regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void OkresBoxEnbled(object sender, RoutedEventArgs e)
        {
            CyklBox.IsEnabled = true;
        }

        private void OkresBoxDisebled(object sender, RoutedEventArgs e) //NIE WIEM JAK NAPISAĆ DISEBLED NIE CHCE MI SIE SPRAWDZAC XDDDD
        {
            CyklBox.IsEnabled = false;
        }

        private void DodajTransakcje(object sender, RoutedEventArgs e)
        {
            //przed tem niech doda jakos ten wydatek/wplyw idk wypelni wartosci, returm czy cos XD
            this.Close();   //zamyka okno
        }
    }
}
