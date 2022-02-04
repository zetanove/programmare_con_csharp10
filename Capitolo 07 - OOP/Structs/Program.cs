/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: strutture
 */


using Structs;

Point pt = new Point();
Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);

Point pt2 = pt;
Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);
pt2.X = 11;
pt2.Y = 22;
Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);

pt = new Point(1, 1);
pt2 = new Point(3, 4);
Point sum = pt.AddToPoint(pt2);

Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);

//struct per riferimento
pt = new Point(1, 1);
pt2 = new Point(3, 4);
pt.AddToPoint(ref pt2);

Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);



//C# 10: espressione with con struct
Point pt3 = pt with { X = 123 };
Console.WriteLine("pt3: {0}, {1}", pt3.X, pt3.Y);

//ref struct
NuovaStruct ns = new NuovaStruct();
ns.Num = 123;
//object o = ns; //ERRORE boxing non possibile

struct Container
{
    //public NuovaStruct field; //errore, una ref struct non può essere usata come campo di una struct normale
}

ref struct Container2
{
    public NuovaStruct field;
    public Span<int> spanInt;
}