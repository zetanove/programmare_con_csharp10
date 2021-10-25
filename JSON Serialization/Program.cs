using System.Text.Json;

public class Program
{
    public static async Task Main()
    {
		Veicolo v = new() { ID = 1, Attivo = true, Targa = "AB123CD", Marca = "Jeep", Modello = "Renegade" };

		string json = JsonSerializer.Serialize(v);
		Console.WriteLine(json);


		Veicolo veicolo = JsonSerializer.Deserialize<Veicolo>(json);


		List<Veicolo> lista = new List<Veicolo>();
		lista.Add(v);
		lista.Add(new Veicolo { ID = 2, Attivo = false, Targa = "EF456GH", Marca = "Nissan", Modello = "Micra" });

		json = JsonSerializer.Serialize(lista);

		List<Automobile> auto=JsonSerializer.Deserialize<List<Automobile>>(json);


		Veicolo v3 = new() { ID = 1, Attivo = true, Targa = "AB123CD", Marca = "Jeep", Modello = "Renegade" };
		v3.Motore = new Motore { TipoCarburante="Benzina", Cilindrata=1300 };

		json = JsonSerializer.Serialize(v3);
		Console.WriteLine(json);

		veicolo = JsonSerializer.Deserialize<Veicolo>(json);

		HttpClient client = new HttpClient();
		var response = await client.GetStringAsync("https://ipinfo.io/8.8.8.8/geo");
		var info = JsonSerializer.Deserialize<IpInfo>(response);
		Console.WriteLine(info);
	}
	
}

public record struct IpInfo
{
	public string ip { get; set; }
	public string hostname { get; set; }
	public bool anycast { get; set; }
	public string city { get; set; }
	public string region { get; set; }
	public string country { get; set; }
	public string loc { get; set; }
	public string org { get; set; }
	public string postal { get; set; }
	public string timezone { get; set; }
	public string readme { get; set; }
}




public class Veicolo
{
	public int ID { get; set; }
	public bool Attivo { get; set; }
	public string Targa { get; set; }
	public string Marca { get; set; }
	public string Modello { get; set; }

	public Motore Motore { get; set; }
}


public readonly record struct Automobile(string Targa,string Marca, string Modello);

public class Motore { 
	public string TipoCarburante { get; set; }
    public int Cilindrata { get; set; }
}

