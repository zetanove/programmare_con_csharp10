/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: ltibi valore nullable e tipi anonimi
 */

//un int che assume anche valore null
int? i = null;
Console.WriteLine(i);
//oppure un valore numerico
i = 1;
Console.WriteLine(i);

//creare un oggetto di un tipo anonimo, senza una definizione di classe
var cliente = new { Nome = "mario", Cognome = "rossi", Età = 50 };
Console.WriteLine("{0} {1} ha {2} anni", cliente.Nome, cliente.Cognome, cliente.Età);

