using System;
using System.Collections.Generic;
using System.Text;

namespace Metodi
{
    public class Ricorsione
    {
        public int Fattoriale(int n)
        {
            if (n <= 1)
                return n;
            return n * Fattoriale(n - 1); //moltiplica n per il risultato dello stesso metodo Fattoriale di n - 1
        }
    }
}
