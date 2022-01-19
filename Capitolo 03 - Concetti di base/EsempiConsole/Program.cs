/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: Esempi di utilizzo della classe Console
 */


Console.Title = "Esempio Console IO";
Console.BackgroundColor = ConsoleColor.White; //imposta il colore bianco come sfondo
Console.Clear();
Console.ForegroundColor = ConsoleColor.Blue; //stampa il testo in blu

Console.Write("Hello");
Console.Write(" ");
Console.Write("World");
string str = "Hello World";
Console.WriteLine(str);

int i = 123;
bool b = true;
Console.WriteLine(i);
Console.WriteLine(b);

string format = "ciao {0}, ecco il numero {1}";
Console.WriteLine(format, "Antonio", 123);

//errore, manca un parametro di indice 3
//Console.WriteLine("stampo tre numeri: {0}, {1}, {2}, {3}", 1, 2, 3);
Console.WriteLine("stampo i numeri {1}, {0}, {0}", 1, 2);

float num = 1.2F;
Console.WriteLine("|{0, 5}|", num); //allinea a destra
Console.WriteLine("|{0, -5}|", num); //allinea a sinistra
num = 1.23456789F;
Console.WriteLine("|{0, 5}|", num);

Console.OutputEncoding = System.Text.Encoding.UTF8;
double val = 123.456789D;
Console.WriteLine("currency:      {0:C2}", val);
Console.WriteLine("decimal:       {0:D5}", 123);
Console.WriteLine("esponenziale:  {0:E2}", val);
Console.WriteLine("virgola fissa: {0:F3}", val);
Console.WriteLine("generale:      {0:G}", val);
Console.WriteLine("numerico:      {0:N4}", 123456789.123456789);
Console.WriteLine("percent:       {0:P2}", 0.123);
Console.WriteLine("round trip:    {0:R}", val);
Console.WriteLine("esadecimale:   {0:X}", 123);

//identificatore segnaposto cifre
Console.WriteLine("{0:#.###}", 1.23456);
Console.WriteLine("{0:##,##}", 123.456);
Console.WriteLine("{0:(+##)###-###-###}", 39123456789);

//lettura da console
str = Console.ReadLine();
Console.WriteLine("Ciao " + str);

//interpolazione di stringhe
string nome = "Caterina";
int età = 37;
Console.WriteLine($"{nome} ha {età} anni");


Console.ReadLine();