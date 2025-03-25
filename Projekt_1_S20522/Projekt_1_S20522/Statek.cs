using Projekt_1_S20522.Kontenery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522
{
    internal class Statek
    {
        private ListaKontenerow listaKontenetow;

        private string nazwa;
        private int maxPredkosc;
        private int maxLiczbaKontenerow;
        private int maxMasaKontenerowWTonach;
        public void WypiszSzegoly()
        {
            Console.WriteLine("nazwa:"+ nazwa);
            Console.WriteLine("Predkość maksyalna w węzłach:" + maxPredkosc);
            Console.WriteLine("Maksymalna liczba kontenerow:" + maxLiczbaKontenerow);
            Console.WriteLine("Maksymalna waga kontenerow w tonach:" + maxMasaKontenerowWTonach);

            Console.WriteLine("Kontenery:");
            listaKontenetow.Wypisz();
        }

        public bool PrzyjmieKontener(Kontener kontener)
        {
            return maxLiczbaKontenerow < listaKontenetow.Count
                && listaKontenetow.MasaWTonach + kontener.MasaCalkWTonach <= maxMasaKontenerowWTonach;
        }

        public bool PrzyjmieListeKontenerow(ListaKontenerow lista)
        {
            return maxLiczbaKontenerow <= listaKontenetow.Count+lista.Count
              && listaKontenetow.MasaWTonach + lista.MasaWTonach <= maxMasaKontenerowWTonach;
        }

        public bool MozliweZastapienie(Kontener kontener1, Kontener kontener2)
        {
            if(kontener1.MasaCalkWTonach>=kontener2.MasaCalkWTonach)
            {
                return true;
            }
            else
            {
                double roznica = kontener2.MasaCalkWTonach - kontener1.MasaCalkWTonach;
                return listaKontenetow.MasaWTonach + roznica <= maxMasaKontenerowWTonach;
            }
        }
        
        public void Zastap(Kontener kontener1, Kontener kontener2)
        {
            listaKontenetow.Zastap(kontener1, kontener2);
        }


        public void Dodaj(Kontener kontener)
        {
            listaKontenetow.Dodaj(kontener);
        }
        public void Dodaj(ListaKontenerow lista)
        {
            listaKontenetow.Dodaj(lista);
        }
        public void Usun(Kontener kontener)
        {
            listaKontenetow.Usun(kontener);
        }
        public Kontener Wybierz(string text = "wybierz kontener:")
        {
            return listaKontenetow.Wybierz(text);
        }

        public string Nazwa
        {
            get
            {
                return nazwa;
            }
        }

        public int MaxPredkosc
        {
            get
            {
                return maxPredkosc;
            }
        }

        
        
        public int MaxLiczbaKontenerow
        {
            get
            {
                return maxLiczbaKontenerow;
            }
        }
        public int LiczbaKontenerow
        {
            get
            {
                return listaKontenetow.Count;
            }
        }

        public int MaxMasaKontenerowWTonach
        {
            get
            {
                return maxMasaKontenerowWTonach;
            }
        }

        public int MasaKontenerowWTonach
        {
            get
            {
                return (int)(listaKontenetow.MasaWTonach+0.5);
            }
        }
    }
}
