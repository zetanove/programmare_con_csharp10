/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4:
 * Scrivere un’applicazione Console che richieda all’utente l’inserimento
 * di un numero che rappresenta le ore, e stampi il numero di minuti e
 * secondi corrispondenti (per es. 1 ora = 60 minuti = 3600 secondi).
 */

Console.WriteLine("Inserisci il numero di ore:");
int ore = int.Parse(Console.ReadLine());
int minuti = ore * 60;
Console.WriteLine($"{ore} ore corrispondono a {minuti} minuti");

Console.WriteLine("Inserisci il numero di minuti:");
minuti = int.Parse(Console.ReadLine());


int secondi = minuti * 60;
Console.WriteLine($"{minuti} minuti corrispondono a {secondi} secondi");


