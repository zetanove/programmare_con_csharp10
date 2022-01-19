// See https://aka.ms/new-console-template for more information
Console.WriteLine("Attributi generici!");

var attribytes=typeof(MiaClasse).GetCustomAttributes(false);

foreach (var attri in attribytes)
{
    Console.WriteLine(attri);
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class Attr<T> : Attribute
{ }

[Attr<string>]
public class MiaClasse
{
    [Attr<string>]
    [Attr<int>]
    public void Method()
    {
    }
}