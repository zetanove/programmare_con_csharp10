Console.WriteLine("Index e Range");

int[] vettore = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int secondo = vettore[1];
int ultimo = vettore[vettore.Length - 1];
Console.WriteLine($"secondo: {secondo}, ultimo: {ultimo}");

Index index1 = 1;
Index indexLast = ^1;

secondo = vettore[index1];
ultimo = vettore[indexLast];

Console.WriteLine($"secondo: {secondo}, ultimo: {ultimo}");

int[] intervallo = vettore[1..^4]; //2, 3, 4, 5, 6
Console.WriteLine(string.Join(',', intervallo));

intervallo = vettore[^2..^0]; //9, 10
Console.WriteLine(string.Join(',', intervallo));

var tutti = vettore[..];
var fino4 = vettore[..4];
var dal6 = vettore[6..];

Console.WriteLine(string.Join(',', tutti));
Console.WriteLine(string.Join(',', fino4));
Console.WriteLine(string.Join(',', dal6));

Range r = 3..^3;
var fetta = vettore[r];
Console.WriteLine(string.Join(',', fetta));

ref int refUltimo = ref vettore[indexLast];
refUltimo = 123;
ultimo = vettore[indexLast];
Console.WriteLine($"secondo: {secondo}, ultimo: {ultimo}");
