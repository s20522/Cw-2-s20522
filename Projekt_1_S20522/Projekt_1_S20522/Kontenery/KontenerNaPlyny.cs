using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Kontenery
{
    internal class KontenerNaPlyny : Kontener, IHazardNotifier
    {
        public void InformujONiebezpiecznejSutuacji(string numerSeryjny, string informacja)
        {
            Console.WriteLine($"{numerSeryjny}: {informacja}");
        }
     
        
        public override bool ZaladujKontener(int masa, string rodzajTowaru, bool niebezpieczny = false)
        {
            
            double maxProcentNapelnienia = 90;
            if(niebezpieczny)
            {
                maxProcentNapelnienia = 50;
            }

            if (masa + masaLadunkuWKg < masaLadunkuMax * (maxProcentNapelnienia/100))
            {
                return base.ZaladujKontener(masa, rodzajTowaru, niebezpieczny);
            }
            else
            {
                if(niebezpieczny)
                {
                    InformujONiebezpiecznejSutuacji(NumerSeryjny, "Przekroczona masa łudunku niebezpiecznego gazu");
                }
                else
                {
                    InformujONiebezpiecznejSutuacji(NumerSeryjny, "Przekroczona masa łudunku gazu");
                }
                
                return false;
            }

            
        }
        protected override char Oznaczenie
        {
            get
            {
                return 'L';
            }
        }

        public override string Rodzaj
        {
            get
            {
                return "na płyny";
            }
        }

    }
}
