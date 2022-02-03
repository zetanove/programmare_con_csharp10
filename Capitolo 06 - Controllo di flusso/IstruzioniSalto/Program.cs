/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: istruzioni salto
 */
using System;

namespace IstruzioniSalto
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
        //istruzione goto
        inizio:
            Console.WriteLine("hello world");
            count++;
            if (count < 10)
                goto inizio;


            //goto in for innestati
            int[,] array = {
	            {1,2,3,4,5},
	            {6,7,8,9,10}
            };

            int cercato = 3;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == cercato)
                    {
                        goto trovato;
                    }
                }
            }
            Console.WriteLine("Il numero non è stato trovato");
            goto nontrovato;

        trovato:
            Console.WriteLine("Il numero è stato trovato");

        nontrovato:
            Console.WriteLine("fine ricerca");


            //goto in switch
            decimal prezzo=5;
            decimal sconto = 2;
            decimal prevendita = 0.5m;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            switch(day)
            {
                case DayOfWeek.Monday:
                    prezzo += 5;
                    break;

                case DayOfWeek.Tuesday:
                    prezzo-=sconto;
                    goto case DayOfWeek.Monday;
                    
                case DayOfWeek.Sunday:
                    prezzo+=2;
                    goto default;

                default:
                    prezzo += prevendita;
                    break;
            }
            Console.WriteLine(prezzo);


        }
    
    }
}
