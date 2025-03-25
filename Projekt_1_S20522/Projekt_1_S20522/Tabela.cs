using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt_1_S20522
{
    internal class Tabela
    {
        List<string> nazwyKolumn;
        List<int> szerokosciKolumn;

        public Tabela()
        {
            nazwyKolumn = new List<string>();
            szerokosciKolumn = new List<int>();
        }

        public void DodajKolumne(string nazwa, int szerokosc=0)
        {
            if (szerokosc == 0)
            {
                szerokosc = nazwa.Length;
            }
            nazwyKolumn.Add(nazwa);
            szerokosciKolumn.Add(szerokosc);
        }


        private void WypiszLinie()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("+");
            for (int i = 0; i < nazwyKolumn.Count; i++)
            {
                for(int j=0; j<szerokosciKolumn[i]+2; j++)
                {
                    builder.Append("-");
                }
                builder.Append("+");
            }
            Console.WriteLine(builder.ToString());
        }
        public void WypiszNaglowek()
        {
            WypiszLinie();
            StringBuilder builder = new StringBuilder();

            builder.Append("| ");
            for(int i=0; i< nazwyKolumn.Count; i++)
            {
                builder.Append(WypiszText(nazwyKolumn[i], szerokosciKolumn[i]));
                builder.Append(" | ");
            }
            Console.WriteLine(builder.ToString());
            WypiszLinie();
        }

        public void RozpocznijNowyWiersz()
        {
            Console.Write("| ");
        }
        public void ZakonczWiersz()
        {
            Console.WriteLine();
        }
        public void DodajWartosc(int liczba, int indexKolumny)
        {
            Console.Write(WypiszText(liczba+"", szerokosciKolumn[indexKolumny], true)+" | ");
        }
        public void DodajWartosc(string text, int indexKolumny)
        {
            Console.Write(WypiszText(text, szerokosciKolumn[indexKolumny]) + " | ");
        }

        public void WypiszKoniec()
        {
            WypiszLinie();
        }
        

        private string WypiszText(string text, int dlugosc, bool doPrawej = false)
        {
            if(text.Length>dlugosc)
            {
                text = text.Substring(0, dlugosc - 3);
                text = text + "...";
            }
            if (doPrawej)
            {
                text = text.PadLeft(dlugosc);
            }
            else
            {
                text = text.PadRight(dlugosc);
            }
            return text;
        }
    }


}
