


Persona p1 = new Persona("Antonio", "Pelleriti", new DateTime(2000, 4, 18));
Persona p2 = new Persona("Antonio", "Pelleriti", new DateTime(2000, 4, 18));
Persona p3 = p1 with { Nome = "Matilda" };
Console.WriteLine(p1);
Console.WriteLine(p3);

Console.WriteLine(p1 == p2); //true
Console.WriteLine(p1.Equals(p3)); //false

Point3D p = new Point3D();
Console.WriteLine(p);

var rp1 = new RPoint3D() { X = 1, Y = 2, Z = 3 };
Console.WriteLine(rp1);

var rp2 = new RPoint3D { X = 1, Y = 2, Z = 3 };

Console.WriteLine(rp1==rp2);


public partial record class Persona(string Nome, string Cognome, DateTime DataNascita);


public record class Impiegato(string matricola)
{
    public int Matricola { get; init; }
}


struct Point3D
{
    public double X;
    public double Y;
    public double Z;
}

record struct RPoint3D
{
    public double X;
    public double Y;
    public double Z;
}

record struct RPoint3Db(double X, double Y, double Z);


