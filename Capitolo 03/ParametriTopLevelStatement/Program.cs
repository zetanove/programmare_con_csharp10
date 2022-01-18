/*Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: parametri applicazione
 */

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine($"parametro = {arg}");
    }
}
else
{
    Console.WriteLine("Nessun parametro");
}
