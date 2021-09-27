/* Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 5: checked unchecked
 */

byte b1 = 200;
byte b2 = 150;
byte somma = (byte)(b1 + b2);

byte min = Byte.MinValue;
byte underflow = (byte)(min - 1);
byte max = Byte.MaxValue;

try
{
    byte val = checked(max++);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
