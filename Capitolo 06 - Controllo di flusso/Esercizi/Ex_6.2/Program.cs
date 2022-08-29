/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6:
 * Esercizio 6.2) Scrivere un’applicazione Console che richieda all’utente l'inserimento
   di infiniti numeri, li sommi, ed esca dal programma alla pressione
   del tasto X. Prima di uscire stampi la somma dei numeri inseriti
 */

using System;

Console.WriteLine("Inserisci infiniti numeri, per terminare inserisci X");
int somma = 0;
string str;
while (true)
{
    str = Console.ReadLine().ToUpper();
    if (str == "X")
    {
        break;
    }
    somma += int.Parse(str);
}

Console.WriteLine($"Somma dei numeri inseriti = {somma}");

