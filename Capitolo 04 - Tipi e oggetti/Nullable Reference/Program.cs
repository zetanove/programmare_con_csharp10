// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#nullable enable
string str = null; //genera un warning perchè la variabile non può essere null, sostituire con string? str
//str="hello"
Console.WriteLine(str!.Length); //genera un warning perchè la variabile non può essere null, usando str!.length se la variabile è sicuramente non null
#nullable restore

string str2 = null;
Console.WriteLine(str2.Length); 
