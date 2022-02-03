/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: operatori aritmetici
 */


int a = 10;
int b = 4;
int somma = a + b; //14
int diff = a - b; //6
int molt = a * b; //40
Console.WriteLine($"a={a} b={b}");

Console.WriteLine($"somma={somma}");
Console.WriteLine($"diff={diff}");
Console.WriteLine($"molt={molt}");

//divisione fra interi
int iquoz = a / b; //2 
Console.WriteLine($"divisione intera={iquoz}");
Console.WriteLine($"resto={a%b}");
double dquoz = (double)a / b; //2.5
Console.WriteLine($"divisione con virgola={iquoz}");

int num = 10;
double quoz = num / 2.0d; //5


//resto della divisione
int resto = 0 % 123; // = 0, perché 0 diviso 123 fa 0 con resto di 0. 
resto = 1 % 2; // =1 perché 1 diviso 2 fa 0 con resto di 1
resto = 3 % 3; // =0 perché 3 diviso 3 fa 1 con resto di 0


Console.WriteLine("resto={0}", resto);

//Dividendo due numeri reali si ottiene invece il resto con i decimali:
double dresto = 2.0 % 1.5; // = 0.5, perché 2/1.5 fa 1 con resto di 0.5
Console.WriteLine("resto={0}", dresto);
dresto = 2.5 % 1.5; //=1 perché 2.5/1.5 fa 1 con resto di 1
Console.WriteLine("resto={0}", dresto);

//operatori unari
int pos = 5;
int neg = -pos; //risultato -5


Console.ReadLine();

