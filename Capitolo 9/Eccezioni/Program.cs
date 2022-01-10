/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: eccezioni
 */


int a = 10;
int b = 0;
int risultato = Divide(a, b);
System.Console.WriteLine("{0}", risultato);
        

static int Divide(int x, int y) => x / y;