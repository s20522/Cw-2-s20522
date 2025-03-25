using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Kontenery
{
    internal class KontenerChlodniczy : Kontener
    {
        private int temperatura;

        static Dictionary<string, double> produkty;

        static KontenerChlodniczy()
        {
            produkty = new Dictionary<string, double>();
            produkty.Add("banany", 13.3);
            produkty.Add("czekolada", 18);
            produkty.Add("ryby", 2);
            produkty.Add("mieso", -15);
            produkty.Add("zamrozona pizza", -30);
            produkty.Add("ser", 7.2);
            produkty.Add("parowki", 5);
            produkty.Add("maslo", 20.5);
            produkty.Add("jajka", 19);
        }

        public override bool ZaladujKontener(int masa, string rodzajTowaru, bool niebezpieczny = false)
        {
            if(!produkty.ContainsKey(rodzajTowaru))
            {
                InformujONiebezpiecznejSutuacji(NumerSeryjny, "Proba załadowania kontenera nieznanym towarem");
                return false;
            }
            double minTemperatura = produkty[rodzajTowaru];
            if(temperatura<= minTemperatura)
            {
                InformujONiebezpiecznejSutuacji(NumerSeryjny, "Temperatura w kontenerze jest zbyt niska");
            }

            double maxProcentNapelnienia = 90;
            if (niebezpieczny)
            {
                maxProcentNapelnienia = 50;
            }

            if (masa + masaLadunkuWKg < masaLadunkuMax * (maxProcentNapelnienia / 100))
            {
                return base.ZaladujKontener(masa, rodzajTowaru, niebezpieczny);
            }
            else
            {
                if (niebezpieczny)
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
                return 'C';
            }
        }

        public override void WczytajDane()
        {
            base.WczytajDane();
            Console.Write("podaj temperaturę (w stopniach Celcjusza):");
            temperatura = int.Parse(Console.ReadLine());
        }

        public override void WypiszSzczegoly()
        {
            base.WypiszSzczegoly();
            Console.WriteLine($"temperatura:{temperatura} stopni Celcjusza");
        }
        public override string Rodzaj
        {
            get 
            {
                return "chłodniczy";
            }
        }
    }
}
