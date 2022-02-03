/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: incremento e decremento
 */

int x = 1;
int y = x++; //restituisce x e poi incrementa
Console.WriteLine("x={0} ; y={1}", x, y); //stampa x= 2, y=1

x = 1;
y = ++x; //incrementa x e poi restituisce il valore
Console.WriteLine("x={0} ; y={1}", x, y); //stampa x= 2, y=2

//Analogamente per l’operatore di decremento:
x = 1;
y = x--; //restituisce x e poi decrementa
Console.WriteLine("x={0} ; y={1}", x, y); //stampa x= 0, y=1

x = 1;
y = --x; //decrementa x e poi restituisce il valore
Console.WriteLine("x={0} ; y={1}", x, y); //stampa x= 0, y=0
