/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: esercizio 6.1
 */

using System;

Console.WriteLine("Inserisci il numero di elementi  che conterrà l'array:");
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];
int numero;

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Inserisci il numero {i + 1}:");
    numero = int.Parse(Console.ReadLine());
    array[i] = numero;
}

Console.WriteLine("Stampo array invertito:");
for (int i = n - 1; i >= 0; i--)
{
    Console.WriteLine(array[i]);
}
