/*
/*
 * Programmare con C# 10 guida completa
 * https://amzn.to/3qEZxae
 * Autore: Antonio Pelleriti
 * Capitolo 7: tipi anonimi
 */

var cliente1 = new { Nome = "bill", Cognome = "gates", DataNascita = new DateTime(1955, 10, 28) };
var cliente2 = new { Nome = "steve", Cognome = "jobs", DataNascita = new DateTime(1955, 2, 24) };

Console.WriteLine("cliente1 è un {0}", cliente1.GetType());
Console.WriteLine("cliente2 è un {0}", cliente2.GetType());

Cliente cliente = new Cliente() { Nome = "mark", Cognome = "zuckerberg", DataNascita = new DateTime() };
var cliente3 = new { cliente.Nome, cliente.Cognome, cliente.DataNascita };

Console.WriteLine("cliente3 è un {0}", cliente3.GetType());

//espressione with, introdotta in C# 10 per i tipi anonimi
var cliente4 = cliente1 with { Nome = "guglielmo" };
Console.WriteLine($"{cliente4.Nome} {cliente4.Cognome} {cliente4.DataNascita:d}");



class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }

}
