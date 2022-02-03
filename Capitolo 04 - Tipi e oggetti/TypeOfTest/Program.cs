/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: typeof
 */


int i = 0;
//ottenere un tipo
Type t1 = i.GetType();
Type t2 = typeof(int);
Console.WriteLine(t1.FullName);
Console.WriteLine(t2.FullName);

//verifico se il tipo è primitivo, decimal non lo è
Console.WriteLine(typeof(decimal).IsPrimitive);

Console.ReadLine();
