using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Kontenery
{
    internal class ListaKontenerow
    {
        List<Kontener> kontenery;
        double masaWTonach;
        Tabela tabela;

        public ListaKontenerow()
        {
            kontenery = new List<Kontener>();
            masaWTonach = 0;
            tabela = new Tabela();
            tabela.DodajKolumne("L.P.", 5);
            tabela.DodajKolumne("Nr. seryjny");
            tabela.DodajKolumne("Rodzaj kontenera");
            tabela.DodajKolumne("Ładunek",40);
            tabela.DodajKolumne("Masę ładunku w KG");
            tabela.DodajKolumne("Masę własna w KG");
            tabela.DodajKolumne("Wysokość w cm");
            tabela.DodajKolumne("Głębokość w cm");
        }

        public void StworzKontener()
        {
            Console.WriteLine("Wybierz rodzaj kontenera:");
            Console.WriteLine("L - kontener na płyny");
            Console.WriteLine("G - kontener na gaz");
            Console.WriteLine("C - kontener na chłodniczy");

            char wybor = Console.ReadLine()[0];
            Kontener kontener = null;
            if(wybor == 'L' || wybor == 'l')
            {
                kontener = new KontenerNaGaz();
            }
            if (wybor == 'G' || wybor == 'g')
            {
                kontener = new KontenerNaGaz();
            }
            if (wybor == 'C' || wybor == 'c')
            {
                kontener = new KontenerNaGaz();
            }

            if(kontener != null)
            {
                kontener.WczytajDane();
                Console.WriteLine("STWORZONO KONTENER");
            }
            Dodaj(kontener);
            
        }

        public void Dodaj(Kontener kontener)
        {
            kontenery.Add(kontener);
            masaWTonach += kontener.MasaCalkWTonach;
        }

        public void Dodaj(ListaKontenerow lista)
        {
            kontenery.AddRange(lista.kontenery);
            masaWTonach += lista.MasaWTonach;
        }
        public void Usun(Kontener kontener)
        {
            kontenery.Remove(kontener);
            masaWTonach -= kontener.MasaCalkWTonach;
        }

        public void Usun(ListaKontenerow lista)
        {
            foreach(Kontener kontener in lista.kontenery) 
            {
                kontenery.Remove(kontener);
            }
        }

        public void Wypisz()
        {
            tabela.WypiszNaglowek();
            for (int i=0; i<kontenery.Count; i++)
            {
                tabela.RozpocznijNowyWiersz();
                tabela.DodajWartosc(i + 1, 0);
                tabela.DodajWartosc(kontenery[i].NumerSeryjny, 1);
                tabela.DodajWartosc(kontenery[i].Rodzaj, 2);
                tabela.DodajWartosc(kontenery[i].RodzajTowaru, 3);
                tabela.DodajWartosc(kontenery[i].MasaLadunkuWKg, 4);
                tabela.DodajWartosc(kontenery[i].MasaWlasnaWKg, 5);
                tabela.DodajWartosc(kontenery[i].WysokoscWCm, 6);
                tabela.DodajWartosc(kontenery[i].GlebokoscWCm, 7);
                tabela.ZakonczWiersz();
            }
            tabela.WypiszKoniec();
        }

        public Kontener Wybierz(string text = "wybierz kontener:")
        {
            Wypisz();
            Console.WriteLine(text);
            int numer = int.Parse(Console.ReadLine());
            return kontenery[numer-1];
        }

        public void Zastap(Kontener kontener1, Kontener kontener2)
        {
            int index = kontenery.IndexOf(kontener1);
            kontenery[index] = kontener2;
        }

        public int Count
        {
            get { return kontenery.Count; }
        }

        public double MasaWTonach
        {
            get
            {
                return masaWTonach;
            }
            
        }

        public void ZaladujWybranyKontener()
        {
            Kontener kontener = Wybierz();

            Console.Write("podaj rodzaj towaru:");
            string rodzajTowaru = Console.ReadLine();
            Console.Write("podaj mase towaru w kg:");
            int masa = int.Parse(Console.ReadLine());
            Console.Write("czy towar jest niebezpieczny? (t/n)");
            char odp = Console.ReadLine()[0];
            bool niebezpieczny = (odp == 't' || odp == 'T');

            if (kontener.ZaladujKontener(masa, rodzajTowaru, niebezpieczny))
            {
                Console.WriteLine("ZAŁADOWANO KONTENER");
            }
            else
            {
                Console.WriteLine("NIE UDAŁO SIĘ ZAŁADOWAC KONTENERA");
            }
        }
    }
}
