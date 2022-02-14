/*
 * Programmare con C# 10
 * Autore: Antonio Pelleriti
 * capitolo 5
 * esercizio 1
 * Scrivere un’applicazione Console che richieda all’utente l’inserimento
 * di due numeri e ne stampi Somma, Sottrazione, Moltiplicazione e Divisione.
 */

Console.WriteLine("Inserisci numero 1:");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci numero 2:");
int b = int.Parse(Console.ReadLine());
Console.WriteLine($"a + b = {a + b}");
Console.WriteLine($"a - b = {a - b}");
Console.WriteLine($"a * b = {a * b}");
Console.WriteLine($"a / b = {(double)a / b}");
