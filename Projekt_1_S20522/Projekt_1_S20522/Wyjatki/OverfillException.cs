using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1_S20522.Wyjatki
{
    internal class OverfillException : Exception
    {
        public OverfillException(string numerSeryjny) : base("Przeładowanie kontenera: "+ numerSeryjny)
        {
            
        }
    }
}
