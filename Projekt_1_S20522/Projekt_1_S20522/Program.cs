using Projekt_1_S20522.Kontenery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaKontenerow konteneryWPorcie = new ListaKontenerow();
            ListaStatkow listaStatkow = new ListaStatkow();
            int wybor = 0;
            while (wybor != 14)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1 - wypisz kontenery");
                Console.WriteLine("2 - wypisz informacji o wybranym kontenerze");
                Console.WriteLine("3 - stwórz kontener danego typu");
                Console.WriteLine("4 - usuń kontener");
                Console.WriteLine("5 - załaduj ładunek do kontenera");
                Console.WriteLine("6 - załaduj kontener na statek");
                Console.WriteLine("7 - załaduj liste kontenerów na statek");
                Console.WriteLine("8 - usuń kontener ze statku");
                Console.WriteLine("9 - rozładuj kontener");
                Console.WriteLine("10 - zastąp kontener na statku o danym numerze innym kontenerem");
                Console.WriteLine("11 - przenieś kontener między dwoma statkami");
                Console.WriteLine("12 - wypisz statki");
                Console.WriteLine("13 - wypisz informacji o wybranym statku i jego ładunku");
                Console.WriteLine("14 - wyjście z prorgamu");

                Console.Write("wybor:");
                wybor = int.Parse(Console.ReadLine());
                Kontener kontener;
                Statek statek;
                switch (wybor)
                {
                    case 1:
                        konteneryWPorcie.Wypisz();
                        break;
                    case 2:
                        kontener = konteneryWPorcie.Wybierz();
                        kontener.WypiszSzczegoly();
                        break;
                    case 3:
                        konteneryWPorcie.StworzKontener();
                        break;
                    case 4:
                        kontener = konteneryWPorcie.Wybierz();
                        konteneryWPorcie.Usun(kontener);
                        break;
                    case 5:
                        konteneryWPorcie.ZaladujWybranyKontener();
                        break;
                    case 6:
                        listaStatkow.ZaladujKontener(konteneryWPorcie);
                        break;
                    case 7:
                        listaStatkow.ZaladujListeKontenerow(konteneryWPorcie);
                        break;
                    case 8:
                        statek = listaStatkow.Wybierz();
                        statek.Usun(statek.Wybierz());
                        Console.WriteLine("KONTENER ZOSTAŁ USUNIĘTY ZE STATKU");
                        break;
                    case 9:
                        kontener = konteneryWPorcie.Wybierz();
                        kontener.RozladujLadunek();
                        Console.WriteLine("ŁADUNEK ZOSTAŁ ROZŁADOWANY");
                        break;
                    case 10:
                        listaStatkow.ZastapKontenerNaStatku(konteneryWPorcie);
                        break;
                    case 11:
                        listaStatkow.PrzeniesKontenerMiedzyStatkami();
                        break;
                    case 12:
                        Console.WriteLine("Statki:");
                        listaStatkow.Wypisz();
                        break;
                    case 13:
                        statek = listaStatkow.Wybierz();
                        statek.WypiszSzegoly();
                        break;
                }
            }


        }

        
    }
}
