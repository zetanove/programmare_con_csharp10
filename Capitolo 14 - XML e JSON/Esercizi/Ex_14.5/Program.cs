using System.Text.Json;
using Ex_14._5;

Studente s=new Studente("Antonio", "Pelleriti", "180777");

string json = JsonSerializer.Serialize(s);
Console.WriteLine(json);