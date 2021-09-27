// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#nullable enable
string? str = null; //genera un warning perchè la variabile non può essere null
Console.WriteLine(str!.Length); //genera un warning perchè la variabile non può essere null
#nullable restore

string str2 = null;
Console.WriteLine(str2.Length); 
