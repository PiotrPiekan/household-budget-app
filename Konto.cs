using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Konto
    {
        private float saldo { get; set; } = 0;
        private string wlasciciel = String.Empty;
        private float saldo_poczatkowe = 0;

        List<Transakcja> wplywy = new List<Transakcja>();
        List<Transakcja> wydatki = new List<Transakcja>();

        public void SetWlasciciel(string value)
        {
            if (value == null) return;
            else wlasciciel = value;
        }

        public Konto(string w, float s_pocz)
        {
            saldo_poczatkowe = s_pocz;
            wlasciciel = w;
        }

        public void PrzeliczOdNowa()
        {
            saldo = 0;
            saldo = saldo_poczatkowe;
            foreach (Transakcja t in wplywy)
            {
                saldo += t.kwota;
            }

            foreach (Transakcja t in wydatki)
            {
                saldo -= t.kwota;
            }
        }


    }
}
