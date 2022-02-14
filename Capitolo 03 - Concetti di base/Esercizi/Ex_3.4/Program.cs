/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: esercizio 4
 * Scrivere un’applicazione Console che legga il nome digitato dall’utente,
 * stampi la stringa "Ciao NOME, premi un tasto per uscire" e si chiuda
 * dopo la pressione di un tasto.
 */

Console.WriteLine("Inserisci il tuo nome: ");
string nome = Console.ReadLine();
Console.WriteLine($"Ciao {nome}, premi un tasto per uscire.");
Console.ReadKey();
