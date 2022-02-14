/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4:
 * Esercizio 3) Scrivere un’applicazione Console che richieda all’utente l’inserimento di 5
 * numeri interi, li salvi in un array, e poi ne calcoli e stampi il minimo e il massimo, poi la
 * media con 2 cifre decimali.
 * nel capitolo 4 è da svolgere senza cicli
 */

int[] array = new int[5];
int max, min;
Console.WriteLine("Inserisci 5 numeri interi:");

Console.WriteLine("Numero 1: ");
array[0] = int.Parse(Console.ReadLine());
max = array[0];
min = array[0];

Console.WriteLine("Numero 2: ");
array[1] = int.Parse(Console.ReadLine());
if (array[1] > max)
    max = array[1];
if (array[1] < min)
    min = array[1];

Console.WriteLine("Numero 3: ");
array[2] = int.Parse(Console.ReadLine());
if (array[2] > max)
    max = array[2];
if (array[2] < min)
    min = array[2];

Console.WriteLine("Numero 4: ");
array[3] = int.Parse(Console.ReadLine());
if (array[3] > max)
    max = array[3];
if (array[3] < min)
    min = array[3];

Console.WriteLine("Numero 5: ");
array[4] = int.Parse(Console.ReadLine());
if (array[4] > max)
    max = array[4];
if (array[4] < min)
    min = array[4];

double somma = (array[0] + array[1] + array[2] + array[3] + array[4]);
Console.WriteLine($"media: {somma / 5:n2}");
Console.WriteLine($"max: {max}");
Console.WriteLine($"min: {min}");
