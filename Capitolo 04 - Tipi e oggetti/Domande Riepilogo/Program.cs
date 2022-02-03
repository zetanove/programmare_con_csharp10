/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: domande riepilogo
 */


//domanda 1: d
string str = "";
int len=str.Length;


//domanda 2: c
Giorni g = Giorni.Dom;
Console.WriteLine((int)g);

float f = 0.0F;
//domanda 4: a
//non è possibile convertire implicitamente
//int i = f;

object obj = 123;
//domanda 5: b
Type t = obj.GetType();
Console.WriteLine(t);

//domanda 6: c
int[] array = new int[5];
array[4] = 1;

//domanda 7: a
#nullable enable
string? stringa = null;
#nullable restore

//domanda 8: a
var figlia = new { Nome = "Matilda", Cognome = "Pelleriti" };  //errata corrige, nel libro manca il new


//domanda 9: b
int[] array2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
foreach(var n in array2[2..^2])
    Console.WriteLine(n);


enum Giorni { Lun = 1, Mar, Mer, Gio, Ven, Sab, Dom };