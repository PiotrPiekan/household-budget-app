using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Transakcja
    {
        public string nazwa;
        public float kwota;
        DateTime data;
        TimeSpan zaIleNastepna;     //do wydatkow stalych - co ile transakcja sie powtarza
        enum kategorie { Jedzenie, Dom, Rozrywka, Rachunki, Zwierzeta, Kultura } //tu zrobić wybór kategori z listy w okienku graficznym 

        public Transakcja(string n, float k, DateTime d, TimeSpan t)
        {
            this.nazwa = n;
            this.kwota = k;
            this.data = d;
            this.zaIleNastepna = t;
        }
    }
}
