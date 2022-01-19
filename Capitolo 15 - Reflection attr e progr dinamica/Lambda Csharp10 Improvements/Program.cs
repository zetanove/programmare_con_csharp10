/*  
 *  Antonio Pelleriti
 *  Programmare con C# 10 guida completa
 *  Capitolo 15, attributi per lambda e funzioni locali
 */

Console.WriteLine("Lambda C# 10 improvements ");


var lambda =[MyAttr] (int x) => x * 2;

var lambda2 =[MyAttr("attributo per espressione lambda")]
    ([MyAttr("attributo per parametro")] int x) => x * 2;


var lambda3 =[MyAttr,MyAttr2] (int x) => x * 2;

var lambda4 =[MyAttr][MyAttr2] (int x) => x * 2;

var lambda5 =[MyAttr("attributo per espressione lambda")]
([MyAttr("attributo per parametro")] int x) => x * 2;

var lambda6 = ([MyAttr,MyAttr2] int x, [MyAttr][MyAttr2]int y) => x * y;

//return type on lambda expressions
Func<int, int, int> mult =[MyAttr] int (x, y) => x * y;

MethodWithLocalFunc();

/// <summary>
/// Attributes on local function
/// </summary>
void MethodWithLocalFunc()
{
    for (int i = 0; i < 5; i++)
    {
        LocalFunc();
        LocalFunc2(i);
    }

    [MyAttr("attributo per local function")]
    void LocalFunc()
    {
        Console.WriteLine("Funzione locale con attributo");
    }

    [MyAttr("attributo per local function")]
    void LocalFunc2<[MyAttr]T>([MyAttr] T obj)
    {
        Console.WriteLine("Funzione locale con attributo: parametro " + obj);
    }
}





class MyAttr : Attribute
{
    public string? Name { get; init; }

    public MyAttr()
    { }

    public MyAttr(string n)
    {
        Name = n;
    }
}

class MyAttr2 : Attribute
{

}