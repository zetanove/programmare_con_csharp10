using System;
using System.Collections.Generic;
using System.Text;

namespace Metodi
{
    class TestRefReturnLocal
    {
        private int[] numbers = { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 };

        public ref int FindNumber(int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // restituisce un riferimento al numero trovato
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        public void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
