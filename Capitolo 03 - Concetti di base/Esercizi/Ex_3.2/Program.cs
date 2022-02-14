/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: esercizio 2
 * Scrivere un’applicazione Console che utilizzi Top Level Statement
 * e prenda come parametri il nome e il cognome e stampi una stringa del tipo
 * "Ciao NOME COGNOME, oggi è giorno DATA e sono le ORA", dove DATA è la
 * data attuale, e ORA è l’ora corrente.
 */

string nome = args[0];
string cognome = args[1];
Console.WriteLine($"Ciao {nome} {cognome}, oggi è giorno {DateTime.Today:d} e sono le {DateTime.Now:HH:mm:ss}");

