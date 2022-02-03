/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: le enumerazioni
 */

using System.Drawing;

namespace Enumerazioni
{

    enum Misure : byte
    {
        S,
        M,
        L,
        XL,
        XXL
    }

    enum Colori : ulong
    {
        Rosso = 0xFF0000,
        Verde = 0x00FF00,
        Blu = 0x0000FF,
        Red = Rosso,
    }

    [Flags]
    enum GiorniSettimana
    {
        Lunedì = 1,
        Martedì = 2,
        Mercoledì = 4,
        Giovedì = 8,
        Venerdì = 16,
        Sabato = 32,
        Domenica = 64
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lunedì={0}", (int)GiorniSettimana.Lunedì);
            Console.WriteLine("Martedì={0}", (int)GiorniSettimana.Martedì);
            Console.WriteLine("Mercoledì={0}", (int)GiorniSettimana.Mercoledì);
            Console.WriteLine("Giovedì={0}", (int)GiorniSettimana.Giovedì);
            Console.WriteLine("Venerdì={0}", (int)GiorniSettimana.Venerdì);
            Console.WriteLine("Sabato={0}", (int)GiorniSettimana.Sabato);
            Console.WriteLine("Domenica={0}", (int)GiorniSettimana.Domenica);

            GiorniSettimana giorniChiusura = GiorniSettimana.Lunedì | GiorniSettimana.Martedì;

            if (giorniChiusura.HasFlag(GiorniSettimana.Lunedì))
            {
                Console.WriteLine(giorniChiusura);
            }
            if ((giorniChiusura & GiorniSettimana.Lunedì) == GiorniSettimana.Lunedì)
            {
                Console.WriteLine(giorniChiusura);
            }

            Console.WriteLine("Colori.Red==Colori.Rosso: " + (Colori.Red==Colori.Rosso));
        }
    }
}