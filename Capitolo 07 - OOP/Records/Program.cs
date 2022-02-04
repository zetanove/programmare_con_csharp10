/*
 * Programmare con C# 10 guida completa
 * https://amzn.to/3qEZxae
 * Autore: Antonio Pelleriti
 * Capitolo 7: record
 */

Console.WriteLine("Records!");

Persona p1 = new Persona { Nome = "Antonio", Cognome = "Pelleriti" };
Console.WriteLine(p1); //stampa Persona { nome = Antonio, cognome = Pelleriti }
//p.Nome = "nuovo"; //errore


var p2 = new Persona2("Matilda", "Pelleriti");
Console.WriteLine(p2);
Persona2 p3 = new("Matilda", "Pelleriti"); //equivalente alla precedente, con espressione new target-typed di C# 9
Console.WriteLine(p3);
//p3.Nome = "nuovo";  //errore

//uguaglianza
Console.WriteLine(p2 == p3); 
Console.WriteLine(p2.Equals(p3)); 

Persona3 calciatore = new("Edson", "Arantes", "Do Nascimento", "Pelè");
Console.WriteLine(calciatore);

//uso di with per mutazione 
Persona3 calciatore2 = calciatore with { Nome = "Ricardo" };
Console.WriteLine(calciatore2);

Point3D pt1 = new(1,2,3);
Point3D pt2 = new();
Console.WriteLine(pt1); 
Console.WriteLine(pt2);
//C# 10 istruzione with con record struct
Point3D pt3 = pt1 with { X = 0 };

//C# 10 record struct posizionale
public record struct Point3D(int X, int Y, int Z);

readonly record struct Point3DReadOnly(double X, double Y, double Z);

//record persona
public record Persona
{
    public string Nome { get; init; }
    public string Cognome { get; init; }
}

//record posizionale
public record Persona2(string Nome, string Cognome);

//altri parametri
public record Persona3(string Nome, string Cognome, params string[] altriNomi);
