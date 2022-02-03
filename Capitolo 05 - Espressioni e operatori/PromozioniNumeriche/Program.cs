/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: promozioni numeriche
 */

decimal decimal1=1m;
double double1=1.2d;
long long1 = 122L;
ulong ulong1 = 12UL;
short sh1 = 2;
sbyte sb1 = 3;

int i = 10;
var res1=decimal1+i;
Console.WriteLine(res1.GetType().FullName);
var res2 = ulong1 + double1;

Console.ReadLine();
