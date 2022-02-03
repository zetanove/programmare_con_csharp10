/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: null conditional
 */

string str1 = null;
string str2 = "matilda";

int? lunghezza = str1?.Length;
Console.WriteLine(lunghezza);//null
lunghezza = str2?.Length;
Console.WriteLine(lunghezza);//7

int len = str1?.Length ?? 0;
Console.WriteLine(len); //0

Console.ReadLine();
