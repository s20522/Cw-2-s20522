using Projekt_1_S20522.Wyjatki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Kontenery
{
    internal class KontenerNaGaz : Kontener, IHazardNotifier
    {
        public KontenerNaGaz()
        {

        }

        public void InformujONiebezpiecznejSutuacji(string numerSeryjny, string informacja)
        {
            Console.WriteLine($"{numerSeryjny}: {informacja}");
        }


        public override void RozladujLadunek()
        {
            int doPozostawienia = (masaLadunkuMax / 20);
            if (masaLadunkuWKg < doPozostawienia)
            {
                InformujONiebezpiecznejSutuacji(NumerSeryjny, "Zbyt mała ilość pozostawionego gazu w kontenerze");
            }
            else
            {
                masaLadunkuWKg = doPozostawienia;
            }
            
        }

        protected override char Oznaczenie
        {
            get
            {
                return 'G';
            }
        }

        public override string Rodzaj
        {
            get
            {
                return "na gaz";
            }
        }
    }
}
