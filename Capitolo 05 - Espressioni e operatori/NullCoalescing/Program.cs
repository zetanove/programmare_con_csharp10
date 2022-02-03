/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: null coalescing
 */



object nullobj = null;
object obj = 123;
var v1 = nullobj ?? 2; // restituisce 2 perché nullobj è uguale a null
Console.WriteLine(v1);
var v2 = obj ?? 2; //restituisce 123, perché obj è diverso da null;
Console.WriteLine(v1);

//null coalescing a cascata
string str1 = null;
string str2 = null;
string name = str1 ?? str2 ?? "senza nome";
Console.WriteLine(name);
Console.ReadLine();
