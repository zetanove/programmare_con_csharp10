/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: JSON DOM
 */

using System.Text.Json;

string json = @"{
""veicoli"": {
		""veicolo"": [
			{
				""id"": 1,
				""targa"": ""AB123CD"",
				""marca"": ""Jeep"",
				""modello"": ""Renegade""
			},
			{			
				""id"": 2,
				""targa"": ""FA059SC"",
				""marca"": ""Nissan"",
				""modello"": ""Micra"",
				""facoltativa"": true
			}
		]
	}
}
";
PrintJsonDom(json);
UseLinqJson(json);


void PrintJsonDom(string json)
{
	using JsonDocument document = JsonDocument.Parse(json);
	JsonElement root = document.RootElement;
	Console.WriteLine($"root ValueKind= {root.ValueKind}");
	JsonElement veicoliElement = root.GetProperty("veicoli");
	Console.WriteLine($"veicoli ValueKind= {veicoliElement.ValueKind}");

	Console.WriteLine(veicoliElement);
	foreach (JsonElement veicolo in veicoliElement.GetProperty("veicolo").EnumerateArray())
	{
		Console.WriteLine("stampo le proprietà del veicolo con id: " + veicolo.GetProperty("id").GetInt32());

		if (veicolo.TryGetProperty("facoltativa", out var value))
		{
			Console.WriteLine("ha una proprietà facoltativa con valore " + value);
		}

		foreach (JsonProperty property in veicolo.EnumerateObject())
		{
			Console.WriteLine($"{property.Name} {property.Value}");
		}

	}
}

void UseLinqJson(string json)
{
	using JsonDocument document = JsonDocument.Parse(json);
	JsonElement root = document.RootElement;
	JsonElement veicoliElement = root.GetProperty("veicoli");

	var query = from veicolo in veicoliElement.GetProperty("veicolo").EnumerateArray()
				where veicolo.GetProperty("marca").GetString() == "Jeep"
				select new
				{
					ID = veicolo.GetProperty("id").GetInt32(),
					Targa = veicolo.GetProperty("targa").GetString(),
					Modello = veicolo.GetProperty("modello").GetString(),
				};

	foreach (var result in query)
	{
		Console.WriteLine(result);
	}
}