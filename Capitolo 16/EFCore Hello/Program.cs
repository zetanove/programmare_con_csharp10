// See https://aka.ms/new-console-template for more information
using EFCore_Hello;

Console.WriteLine("Hello, EF Core!");

using (var db = new CarContext())
{
	bool created = await db.Database.EnsureCreatedAsync();
	Console.WriteLine(created ? "Database creato" : "Database esistente");
}
