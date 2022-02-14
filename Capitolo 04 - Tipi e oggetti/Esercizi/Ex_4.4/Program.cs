/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4:
 * Esercizio 4) Scrivere un’applicazione Console, con contesto nullable abilitato, che richieda
 * all’utente l’inserimento di una stringa, e poi ne stampi i primi due e gli ultimi
 * due caratteri.
 */

#nullable enable

string? str = Console.ReadLine();

if (str != null && str.Length > 1)
{
    Console.WriteLine("primi due caratteri:" + str[0] + str[1]);
    Console.WriteLine("ultimi due caratteri:" + str[^2] + str[^1]);
}
