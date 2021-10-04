/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: classi
 */

using System;

namespace Classi
{
    public class SmartPhone
    {
        public static int Contatore;
        public const int MaxLunghezzaNome=20;
        public string Marca;
        public string Modello { get; private set; }
        public readonly DateTime CreationTime=DateTime.Now;

        static SmartPhone()
        {
            Contatore = 0;
        }

        public SmartPhone()
        {
            
        }

        //expression body in costruttore
        public SmartPhone(string m) => Marca = Modello = m;

         class Battery
        {
            Battery()
            {
               
            }
        }
    }

    class DefaultValues
    {
        static int count=0;
        public byte b=(byte)count++;
        public sbyte sb=(sbyte)count++;
        public short s=(short)count++;
        public ushort us;
        public int i;
        public uint ui;
        public long l;
        public ulong ul;
        public float f;
        public double d;
        public char ch;
        public bool bo;
        public decimal dec=count++;
        public string str=(count++).ToString();
    }

    class Valori
    {
        int primo = 1; //assegnato per primo
        int secondo = 2; //assegnato per secondo
        int terzo; //Assegnato per terzo il valore predefinito 0

        public Valori()
        {
            //i campi sono già assegnati
            terzo = primo + secondo;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            DefaultValues dv = new DefaultValues();
            Console.WriteLine("byte={0}", dv.b);
            Console.WriteLine("sbyte={0}", dv.sb);
            Console.WriteLine("short={0}", dv.s);
            Console.WriteLine("ushort={0}", dv.us);
            Console.WriteLine("int={0}", dv.i);
            Console.WriteLine("uint={0}", dv.ui);
            Console.WriteLine("long={0}", dv.l);
            Console.WriteLine("ulong={0}", dv.ul);
            Console.WriteLine("float={0}", dv.f);
            Console.WriteLine("double={0}", dv.d);
            Console.WriteLine("char={0}", dv.ch);
            Console.WriteLine("bool={0}", dv.bo);
            Console.WriteLine("decimal={0}", dv.dec);
            Console.WriteLine("string={0}", dv.str);

            Valori v = new Valori();


            SmartPhone sp = new SmartPhone{ Marca=""};
            Console.ReadLine();
        }
    }
}
