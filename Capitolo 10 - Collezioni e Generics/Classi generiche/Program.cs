/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 10: classi generiche
 */

using System;

namespace Classi_generiche
{
    //la classe Lista può contenere elementi di diverso tipo
    public class Lista<T>
    {
        private T[] array;
        public Lista(int len)
        {
            array = new T[len];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public static int Numero;
    }

    class Generica<T, U>
    {
        private T campo1;
        private U campo2;
        public Generica()
        {
            campo1 = default(T);
            campo2 = default(U);
            Console.WriteLine(campo1);
            Console.WriteLine(campo2);
        }
    }

    //vincoli
    class ListaOggetti<T> where T : class
    {
        
    }

    //vincoli ereditati
    class ListaFiglia<T>: ListaOggetti<T> where T:class
    {

    }

    //metodi di estensione
    public static class UtilityClass
    {
        public static Lista<T> Ordina<T>(this Lista<T> obj)
        {
            //ordina elementi e restituisce la lista ordinata
            //implementazione per esercizio
            return obj;
        }
    }

    class SwapClass<T>
    {
        void Swap(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        public U GetDefaultValue<U>()
        {
            return default(U);
        }
    }

    //delegate generico
    public delegate T MioDelegate<T, U>(U val);

    class Program
    {
        static void Main(string[] args)
        {
            //creo una lista di interi
            Lista<int> lista = new Lista<int>(5);
            lista[0] = 1;
            Console.WriteLine(lista[0]);

            //usa metodo di estensione
            lista.Ordina();

            //classe generica innestata
            Lista<Nullable<int>> lista2 = new Lista<Nullable<int>>(10);

            //valori predefiniti
            Generica<int, string> gen = new Generica<int, string>();

            //membro statico
            Lista<int>.Numero = 123;
            var num = Lista<int>.Numero;
            Console.WriteLine(num);

            

            //ListaOggetti<int> lo = new ListaOggetti<int>();//errore perchè int non è un tipo riferimento
            ListaOggetti<object> lo = new ListaOggetti<object>();

            SwapClass<int> sc = new SwapClass<int>();
            Console.WriteLine(sc.GetDefaultValue<int>());


            //interfacce generiche
            TransformerIntString ts = new TransformerIntString();
            var s=ts.Transform(1);

            TransformerIntStringInt tisi = new TransformerIntStringInt();
            string str = tisi.Transform(1);
            int i = tisi.Transform("123");
        }
    }
}
