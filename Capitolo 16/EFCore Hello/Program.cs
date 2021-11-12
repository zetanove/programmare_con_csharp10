// See https://aka.ms/new-console-template for more information
using EFCore_Hello;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, EF Core!");

using (var db = new CarContext())
{
	bool created = await db.Database.EnsureCreatedAsync();
	Console.WriteLine(created ? "Database creato" : "Database esistente");

	await db.Cars.AddAsync(new Car { Targa = "AB123CD", Modello = "Ferrari" });
	var count = await db.SaveChangesAsync();
	Console.WriteLine("{0} record salvati su database", count);

	Car c1 = new Car { Targa = "BC243FE", Modello="Jeep" };
	Car c2 = new Car { Targa = "CD543GD", Modello = "Micra" };
	Car c3 = new Car { Targa = "EF777QW", Modello = "Panda" };

	await db.AddRangeAsync(c1, c2, c3);
	count = await db.SaveChangesAsync();
	Console.WriteLine("{0} record salvati su database", count);


	await db.People.AddAsync(new Person { FirstName = "Antonio", LastName = "Pelleriti" });
	count = await db.SaveChangesAsync();

	var query = db.Cars.Where(c => c.Targa.StartsWith("A"));
	Console.WriteLine(query.ToQueryString());

	Car c = await db.Cars.FindAsync(1);
	if (c != null)
	{
		Console.WriteLine("Targa car con id=1: " + c.Targa);
		c.Targa = "ZZ000YY";
		await db.SaveChangesAsync();
	}

	Car last = await db.Cars.OrderBy(c=>c.CarId).LastAsync();
	db.Cars.Remove(last);
	int deleted = await db.SaveChangesAsync();

	Person p = await db.People.FindAsync(1);
	//p.FirstName = "Matilda"; //errore

	Person updated = p with { FirstName = "Matilda" };
	db.Entry(p).State = EntityState.Detached;

	db.Update(updated);
	count=await db.SaveChangesAsync();

	deleted=await db.Database.ExecuteSqlRawAsync("DELETE FROM Car WHERE CarId=1");
	Console.WriteLine("{0} eliminati", deleted);

	last = await db.Cars.OrderBy(c => c.CarId).LastAsync();
	deleted = await db.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM Car WHERE Targa={last.Targa}");


}
