/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: esercizio 3
 * Scrivere un’applicazione Console che, dato il numero 123.456, lo
 * stampi nei formati valuta, con due cifre decimali, intero, percentuale con una
 * cifra decimale.
 */

using System;

float numero = 123.456f;
Console.WriteLine($"valuta {numero:c2}");
Console.WriteLine($"due cifre decimali {numero:n2}");
Console.WriteLine($"intero {numero:n0}");
Console.WriteLine("percent: {0:P1}", numero / 100);
