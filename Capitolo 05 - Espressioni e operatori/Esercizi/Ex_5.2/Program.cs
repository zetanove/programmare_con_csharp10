/*
 * Programmare con C# 10
 * Autore: Antonio Pelleriti
 * capitolo 5
 * esercizio 2
 * Scrivere un’applicazione Console che richieda all’utente l’inserimento
 * di 2 numeri interi, ed esegua le operazioni di AND e OR bit a bit, e stampi
 * i risultati in formato binario.
 */


Console.WriteLine("Inserisci numero 1:");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci numero 2:");
int b = int.Parse(Console.ReadLine());

var and = a & b;
var or = a | b;
string strAnd = Convert.ToString(and, 2);
string strOr = Convert.ToString(or, 2);

Console.WriteLine($"a & b = {strAnd}");
Console.WriteLine($"a | b = {strOr}");
