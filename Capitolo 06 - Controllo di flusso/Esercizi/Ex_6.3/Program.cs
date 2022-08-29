/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: esercizio 6.3
 * Scrivere un’applicazione Console che richieda all’utente l'inserimento
   di 2 numeri, e quindi una lettera. Se la lettera è S esegua la somma, se
   la lettera è M, esegua la moltiplicazione. Se la lettera è X esca dal programma.
   In tutti gli altri casi stampi un messaggio di errore del tipo “Inserire S per somma,
   M per moltiplicare, X per uscire”.
 */

using System;

Console.WriteLine("Inserisci 2 numeri...");

Console.WriteLine("numero 1:");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("numero 2:");
int b = int.Parse(Console.ReadLine());



while (true)
{
    Console.WriteLine("Inserisci S per eseguire la somma, M per la moltiplicazione, X per uscire");

    var str = Console.ReadLine();
    if (str.ToUpper() == "S")
    {
        Console.WriteLine($"Somma = {a + b}");
    }
    else if (str.ToUpper() == "M")
    {
        Console.WriteLine($"Moltiplicazione = {a * b}");
    }
    else if (str.ToUpper() == "X")
        return;
}
