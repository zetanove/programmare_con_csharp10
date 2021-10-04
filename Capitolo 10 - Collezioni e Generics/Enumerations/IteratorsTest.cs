/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: iteratori
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    public class IteratorsTest
    {
        public IEnumerable<string> GetNames()
        {
            yield return "antonio";
            yield return "caterina";
        }

        Random rand = new Random();
        public IEnumerable<double> GetRandomNumbers(double soglia)
        {
            while (true)
            {
                double d = rand.NextDouble() * 100;
                if (d < soglia)
                    yield break;
                yield return d;
            }
        }

        public IEnumerator<double> HighRandomNumbers
        {
            get
            {
                while (true)
                {
                    double d = rand.NextDouble() * 100;
                    if (d < 10)
                        yield break;
                    yield return d;
                }
            }
        }
    }
}
