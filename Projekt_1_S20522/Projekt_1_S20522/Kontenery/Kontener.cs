using Projekt_1_S20522.Wyjatki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Kontenery
{
    abstract class Kontener : IHazardNotifier
    {
        
        private string numerSeryjny;
        private string rodzajTowaru;
        protected int masaLadunkuWKg;
        protected int masaLadunkuMax;
        private int wysokosc;
        private int masaWlasna;
        private int glebokosc;
        private bool niebezpieczny;

        private int masaWlasnaWKg;
        private static int ostatniNumer = 0;
        public Kontener()
        {
            ostatniNumer++;
            numerSeryjny = $"KON-{Oznaczenie} - {ostatniNumer}";
            rodzajTowaru = string.Empty;
            niebezpieczny = false;
            masaLadunkuWKg = 0;
        }

        public virtual void WczytajDane()
        {
            Console.Write("podaj wysokosc (w cm):");
            wysokosc = int.Parse(Console.ReadLine());
            Console.Write("podaj glebokosc (w cm):");
            glebokosc = int.Parse(Console.ReadLine());
            Console.Write("podaj wagę wlasną (w kg):");
            masaWlasna = int.Parse(Console.ReadLine());
            Console.Write("podaj maksymalną wagę ładunku (w kg):");
            masaLadunkuMax = int.Parse(Console.ReadLine());
        }

        public virtual void WypiszSzczegoly()
        {
            Console.WriteLine("Szczegółowe dane kontenera:");
            Console.WriteLine("numer seryjny:"+ numerSeryjny);
            Console.WriteLine("rodzaj towaru:" + rodzajTowaru);
            Console.WriteLine($"wysokość:{wysokosc} cm");
            Console.WriteLine($"glebokość:{glebokosc} cm");
            Console.WriteLine($"masa własna:{masaWlasna} KG" );
            Console.WriteLine($"maksymalna masa ładunku: {masaLadunkuMax} KG");
            Console.WriteLine($"masa ładunku: {masaLadunkuMax} KG");
        }


        public virtual void RozladujLadunek()
        {
           
            masaLadunkuWKg = 0;
            rodzajTowaru = string.Empty;
        }

        public virtual bool ZaladujKontener(int masa, string rodzajTowaru, bool niebezpieczny = false)
        {
            if (!string.IsNullOrEmpty(this.rodzajTowaru) && this.rodzajTowaru != rodzajTowaru)
            {
                InformujONiebezpiecznejSutuacji(NumerSeryjny, "nie zgodny rodzaj towaru");
                return false;
            }

            if (masaLadunkuWKg+ masa> masaLadunkuMax)
            {
                throw new OverfillException(numerSeryjny);
            }
            masaLadunkuWKg += masa;

            this.rodzajTowaru = rodzajTowaru;

            return true;
        }

        
        public void InformujONiebezpiecznejSutuacji(string numerSeryjny, string informacja)
        {
            Console.WriteLine($"{numerSeryjny}: {informacja}");
        }

        public string NumerSeryjny
        {
            get
            {
                return numerSeryjny;
            }
        }

        protected abstract char Oznaczenie
        {
            get;
        }

        public abstract string Rodzaj
        {
            get;
        }

        public double MasaCalkWTonach
        {
            get
            {
                return (double)(masaWlasnaWKg + masaLadunkuWKg)/1000;
            }
        }

        public int MasaWlasnaWKg
        {
            get
            {
                return masaWlasnaWKg;
            }
        }
        public string RodzajTowaru
        {
            get
            {
                if(string.IsNullOrEmpty(rodzajTowaru))
                {
                    return "BRAK";
                }
                return rodzajTowaru;
            }
        }
        public int MasaLadunkuWKg
        {
            get
            {
                return masaLadunkuWKg;
            }
        }

        public int WysokoscWCm
        {
            get
            {
                return wysokosc;
            }
        }

        public int GlebokoscWCm
        {
            get
            {
                return glebokosc;
            }
        }
    }
}
