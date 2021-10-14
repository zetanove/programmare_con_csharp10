/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13:
 * Esercizio 1) Scrivere un’applicazione Console che avvii tre diversi thread, che a intervalli
 * di tempo differenti (il primo ogni secondo, il secondo ogni 2 secondi, il terzo ogni 3
 * secondi) stampino il proprio nome e l’orario corrente.
 */

using System;
using System.Threading;

namespace Ex_13._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Premi x per uscire");

            bool exit = false;

            Thread th1 = new Thread(() =>
            {
                while (!exit)
                {
                    Console.WriteLine("sono il thread " + Thread.CurrentThread.Name + " esecuzione ogni 1 secondi, sono le " + DateTime.Now);
                    Thread.Sleep(1000);
                }

            });
            Thread th2 = new Thread(() =>
            {
                while (!exit)
                {
                    Console.WriteLine("sono il thread " + Thread.CurrentThread.Name + " esecuzione ogni 2 secondi, sono le " + DateTime.Now);
                    Thread.Sleep(2000);
                }

            });
            Thread th3 = new Thread(() =>
            {
               
                while (!exit)
                {
                    Console.WriteLine("sono il thread " + Thread.CurrentThread.Name + " esecuzione ogni 3 secondi, sono le " + DateTime.Now);
                    Thread.Sleep(3000);
                }

            });

            th1.Name = "th1";
            th2.Name = "th2";
            th3.Name = "th3";

            th1.Start();
            th2.Start();
            th3.Start();

            while(!exit)
            {
                if(Console.ReadKey().Key== ConsoleKey.X)
                {
                    exit = true;
                }
            }

        }
    }
}
