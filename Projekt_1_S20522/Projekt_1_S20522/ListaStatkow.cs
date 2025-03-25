using Projekt_1_S20522.Kontenery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522
{
    internal class ListaStatkow
    {
        List<Statek> listaStatkow;
        Tabela tabela;

        public ListaStatkow()
        {
            listaStatkow = new List<Statek>();
            tabela = new Tabela();
            tabela.DodajKolumne("L.P.", 5);
            tabela.DodajKolumne("Nazwa",30);
            tabela.DodajKolumne("Max prędkośc (węzły)");

            tabela.DodajKolumne("Max ilość kont.");
            tabela.DodajKolumne("Ilość zał. kont.");

            tabela.DodajKolumne("Max masa kont.");
            tabela.DodajKolumne("Masa zał. kont.");
        }
        public void Dodaj(Statek statek)
        {
            listaStatkow.Add(statek);
        }
        public void Usun(Statek statek)
        {
            listaStatkow.Remove(statek);
        }

        public void Wypisz()
        {
            tabela.WypiszNaglowek();
            for (int i = 0; i < listaStatkow.Count; i++)
            {
                tabela.RozpocznijNowyWiersz();
                tabela.DodajWartosc(i + 1, 0);
                tabela.DodajWartosc(listaStatkow[i].Nazwa, 1);
                tabela.DodajWartosc(listaStatkow[i].MaxPredkosc, 2);
                tabela.DodajWartosc(listaStatkow[i].MaxLiczbaKontenerow, 3);
                tabela.DodajWartosc(listaStatkow[i].LiczbaKontenerow, 4);
                tabela.DodajWartosc(listaStatkow[i].MaxMasaKontenerowWTonach, 5);
                tabela.DodajWartosc(listaStatkow[i].MasaKontenerowWTonach, 6);
                tabela.ZakonczWiersz();
            }
            tabela.WypiszKoniec();
        }

        public Statek Wybierz(string text = "wybierz statek:")
        {
            Wypisz();
            Console.WriteLine(text);
            int numer = int.Parse(Console.ReadLine());
            return listaStatkow[numer - 1];
        }

        public void ZaladujKontener(ListaKontenerow konteneryWPorcie)
        {
            Kontener kontener = konteneryWPorcie.Wybierz();
            Statek statek = Wybierz();
            if (statek.PrzyjmieKontener(kontener))
            {
                statek.Dodaj(kontener);
                konteneryWPorcie.Usun(kontener);
                Console.WriteLine("ZAŁADOWANO KONTENER NA STATEK");
            }
            else
            {
                Console.WriteLine("NIE UDAŁO SIĘ ZAŁADOWAĆ KONTENER NA STATEK");
            }
        }

        public void ZaladujListeKontenerow(ListaKontenerow konteneryWPorcie)
        {
            ListaKontenerow listaDoZaladunku = new ListaKontenerow();
            char odp;
            do
            {
                Kontener kontener = konteneryWPorcie.Wybierz();
                listaDoZaladunku.Dodaj(kontener);
                Console.Write("czy dodać kolejny kontener");
                odp = Console.ReadLine()[0];
            } while (odp == 't' || odp == 'T');

            Statek statek = Wybierz();
            if (statek.PrzyjmieListeKontenerow(listaDoZaladunku))
            {
                statek.Dodaj(listaDoZaladunku);
                konteneryWPorcie.Usun(listaDoZaladunku);
            
                Console.WriteLine("ZAŁADOWANO LISTE KONTENERÓW NA STATEK");
            }
            else
            {
                Console.WriteLine("NIE UDAŁO SIĘ ZAŁADOWAĆ LISTY KONTENERÓW NA STATEK");
            }
        }

        public void ZastapKontenerNaStatku(ListaKontenerow konteneryWPorcie)
        {
            Statek statek = Wybierz();
            Kontener kontener1 = statek.Wybierz("wybierz kontener ze statku:");
            Kontener kontener2 = konteneryWPorcie.Wybierz("wybierz kontener z portu:");
            if (statek.MozliweZastapienie(kontener1, kontener2))
            {
                statek.Zastap(kontener1,kontener2 );
                konteneryWPorcie.Zastap(kontener2, kontener1);
                Console.WriteLine("ZASTAPIONO KONTENERY NA STATKU");
            }
        }

        public void PrzeniesKontenerMiedzyStatkami()
        {
            Statek statek1 = Wybierz("wybierz statek z którego pobrać kontener:");
            Kontener kontener = statek1.Wybierz();
            Statek statek2 = Wybierz("wybierz statek na który załadowac kontener:");
                
            if(statek2.PrzyjmieKontener(kontener))
            {
                statek1.Usun(kontener);
                statek2.Dodaj(kontener);
                Console.WriteLine("PRZENIESIONO KONTENERT MIEDZY STATKAMI");
            }
            else
            {
                Console.WriteLine("NIE UDAŁO SIĘ PRZENIEŚĆ KONTENERÓW MIĘDZY STATKAMI");
            }
        }
    }
}
