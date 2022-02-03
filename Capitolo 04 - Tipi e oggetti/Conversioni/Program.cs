/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: conversioni
 */

byte b = 123;
int i = 123;
Console.WriteLine("i={0}", i);

int i2 = 123;
//non è possibile convertire implicitamente
//byte b2 = i2; //Errore
byte b2 = (byte)i2;

char ch = 'a';
int valChar = ch;
Console.WriteLine("{0} = {1}", ch, valChar);

//non è consentito il contrario
//ch = valChar;

byte by1 = 150;
byte by2 = 200;
byte somma = (byte)(by1 + by2);
Console.WriteLine("{0} + {1} = {2}", by1, by2, somma);

//eccezione
//Console.WriteLine("{0} + {1} = {2}", by1, by2, Convert.ToByte(by1 + by2));


//la classe Convert
string str = "123";
int i1 = Convert.ToInt32(str);
double d1 = Convert.ToDouble(str);



int esa = Convert.ToInt32("1AB", 16); //converte dall'esadecimale
int bin = Convert.ToInt32("10010111", 2); //converte dal binario

int dec;
dec = (int)Convert.ChangeType(str, typeof(int));

int intero = 1;
nint ni = intero;
int j = (int)ni; // necessita cast
