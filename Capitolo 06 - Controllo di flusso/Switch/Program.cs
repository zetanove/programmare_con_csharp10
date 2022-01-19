/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: switch
 */

using System.Drawing;

bool b = true;
int num = 1;

switch (num)
{
    case 1:
        b = false;
        goto case 2;
    case 2:
        break;
}

Console.WriteLine(b);

//switch con string case sensitive
string str = "";
switch (str)
{
    case "a":
        break;
    case "A":
        break;
}

//fall through
Console.WriteLine("digita un tasto");
char c = Console.ReadKey().KeyChar;
switch (c)
{
    case 'a':
    case 'e':
    case 'i':
    case 'o':
    case 'u':
        Console.WriteLine("hai digitato la vocale {0}", c);
        break;
    default:
        Console.WriteLine("non hai inserito una vocale");
        break;
}

DayOfWeek day = DateTime.Today.DayOfWeek;

switch (day)
{
    case DayOfWeek.Saturday:
    case DayOfWeek.Sunday:
        Console.WriteLine("riposo");
        break;
    case DayOfWeek.Monday:
        Console.WriteLine("8:00 - 12:00");
        break;
    case DayOfWeek.Tuesday:
        Console.WriteLine("8:00 - 12:00 e 15:00 - 18:00");
        break;
    case DayOfWeek.Wednesday:
        Console.WriteLine("8:00 - 12:00");
        break;
    case DayOfWeek.Thursday:
    case DayOfWeek.Friday:
        Console.WriteLine("8:00 - 12:00");
        break;
}

switch (DateTime.Now.DayOfWeek)
{
    case DayOfWeek.Monday:
        Console.WriteLine("Lunedì chiuso");
        break;
    case < DayOfWeek.Thursday:
        Console.WriteLine("Prima di mercoledì");
        break;
    case >= DayOfWeek.Friday:
        Console.WriteLine("Weekend");
        break;

}

Combinators();
void Combinators()
{
    Console.WriteLine("pattern combinator. Digita un tasto");
    var ch = Console.ReadKey().KeyChar;
    switch (ch)
    {        
        case 'a' or 'e' or 'i' or 'o' or 'u':
            Console.WriteLine("hai digitato la vocale {0}", ch);
            break;
        case (>= 'a' and <= 'z') or (>= 'A' and <= 'Z'):
            Console.WriteLine("hai digitato una lettera {0}", ch);
            break;
        case not (' ' or '\t'):
            Console.WriteLine("non è uno spazio o un tab");
            break;

    }
}

GenericMatch<int>(1);

Person p = new Person() { FirstName = "Matilda" };


string language = "ita";
string greeting = null;

switch (language)
{
    case "eng":
        greeting = "Hello";
        break;
    case "spa":
        greeting = "Hola";
        break;
    case "ita":
        greeting = "Ciao";
        break;
    default:
        greeting = "???";
        break;
}

object obj = null; //provate a sostituire con new Quadrato() o new Cerchio()
switch (obj)
{
    case Quadrato:
        Console.WriteLine("L'oggetto è un quadrato");
        break;
    case null:
        Console.WriteLine("L'oggetto è null");
        break;
    case var o:
        Console.WriteLine($"L'oggetto è di tipo {o.GetType()}");
        break;
};

greeting = language switch
{
    "eng" => "Hello",
    "spa" => "Hola",
    "ita" => "Ciao",
    _ => "???"
};

Console.WriteLine(greeting);

language = "deu";
greeting = language switch
{
    "eng" => "Hello",
    "spa" => "Hola",
    "ita" => "Ciao",
    _ => "???"
};

Quadrato q = new Quadrato();
q.Lato = 5;
Cerchio cerchio = new Cerchio();
cerchio.Raggio = 4;

var areaQuadrato = CalcArea1(q);
Console.WriteLine($"area quadrato {areaQuadrato}");

//funziona da C# 7.1 
static string GenericMatch<T>(T input)
{
    switch (input)
    {
        case int i:
            return "int";
        case string s:
            return "string";
        default:
            return "altro";
    }

}


static double CalcArea1(object obj)
{

    switch (obj)
    {
        case Quadrato { Lato: < 0 } q:
            throw new Exception("Il lato non può essere negativo");
        case Quadrato { Lato: >= 0 } q:
            return q.Lato * q.Lato;
        case Cerchio c:
            return Math.PI * Math.PI * c.Raggio;

        default:
            throw new NotImplementedException();
    };
}

static double CalcArea(object obj)
{
    return obj switch
    {
        Quadrato { Lato: 0 } => 0,
        Quadrato q => q.Lato * q.Lato,
        Cerchio c => Math.PI * Math.PI * c.Raggio,
        _ => throw new NotImplementedException()
    };
}


//static void TestSwitchExpression()
//{
//    object str = "abc";
//    var x = str switch
//    {

//        string s when s.StartsWith("a") => 0,
//        string { Length: 10 } => 1234,
//        string s => s.Length,
//        _ => 1
//    };
//    Console.WriteLine(x);
//}

static string Display(object o) => o switch
{
    Point { X: 0, Y: 0 } p => "origin",
    Point { X: var x, Y: var y } p => $"({x}, {y})",
    _ => "unknown"
};


class Figura
{
    public double Area
    {
        get
        {
            return this switch
            {
                Quadrato q when q.Lato < 0 => throw new ArgumentException(),
                Quadrato q when (q.Lato is > 0 and < 100) => q.Lato * q.Lato,
                Cerchio c => c.Raggio * Math.PI * Math.PI,
                _ => throw new NotImplementedException()
            };
        }
    }
}

class Quadrato : Figura
{
    public double Lato { get; set; }

    public Test ID { get; set; }
}

public class Test
{
    public string Nome { get; set;  }
}

class Cerchio : Figura
{
    public double Raggio { get; set; }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}