/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: null coalescing
 */




#nullable enable
string? str = null;
Console.WriteLine(str.Length); //genera un warning: CS8602 Dereference ofa possibly null reference.
#nullable restore

Console.WriteLine(str!.Length); //evita il warning ma provoca ugualmente eccezione