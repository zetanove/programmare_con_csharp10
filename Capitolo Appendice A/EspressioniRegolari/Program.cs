/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Appendice A: espressioni regolari
 */

using System;
using System.Text.RegularExpressions;

namespace EspressioniRegolari
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\d{2}";
            string input = "oggi ci sono 25 gradi";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(input);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
                Console.WriteLine(match.Index);
                Console.WriteLine(match.Length);
            }

            MatchCollection matches = Regex.Matches(input, "i");
            Console.WriteLine("trovate {0} corrispondenze di 'i' in {1}", matches.Count, input);
            foreach (Match m in matches)
            {
                Console.WriteLine("indice {0}", m.Index);
            }

            input = "La stringa contiene più parole costituite da due caratteri";
            pattern = @"\b\w{2}\b";
            var risultati = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match m in risultati)
            {
                Console.WriteLine(m.Value);
            }

            input = "hello antonio";
            pattern = "[abcde]";
            matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
                Console.WriteLine("at {0}: {1}", m.Index, m.Value); //trova e e a

            input = "a1 h1 b2 h2";
            pattern = @"[a-f]\d";
            matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
                Console.WriteLine("at {0}: {1}", m.Index, m.Value);//a1 b2

            input = "area bare arena mare";
            pattern = @"\bare\w*\b";
            Console.WriteLine("Parola che iniziano per 'are':");
            foreach (Match m in Regex.Matches(input, pattern))
                Console.WriteLine("'{0}' found at position {1}", m.Value, m.Index);

            input = "98065 123 abc 9210";
            pattern = @"\d{5}";
            matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
                Console.WriteLine("at {0}: {1}", m.Index, m.Value);//98065


            pattern = @"(\+\d{2})-(\d{3}-\d{4})";
            input = "In questa stringa ci sono dei numeri 212-555-6666 +39-932-1111 +415-222-3333 +01-888 - 9999 alcuni dei quali sono telefoni con prefisso";
            matches = Regex.Matches(input, pattern);
            foreach (Match mn in matches)
            {
                Console.WriteLine("Prefisso nazione: {0}", mn.Groups[1].Value);
                Console.WriteLine("numero tel.: {0}", mn.Groups[2].Value);
                Console.WriteLine();
            }

            pattern = @"(\w+)\s(\1)";
            input = "In questa frase frase ci sono sono delle parole ripetute";
            foreach (Match mr in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                Console.WriteLine("Duplicato '{0}'", mr.Groups[1].Value);

            pattern = @"(?<dup>\w+)\s(\k<dup>)";
            foreach (Match mr in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                Console.WriteLine("Duplicato '{0}'", mr.Groups["dup"].Value);

            input = "Questa stringa ha troppi spazi bianchi ";
            pattern = "\\s+";
            Regex rgx = new Regex(pattern);
            string replacement = "-";
            string result = rgx.Replace(input, replacement);
            Console.WriteLine(result);

            input = "una frase tutta in minuscolo";
            result = Regex.Replace(input, @"\b[a-z]\w+", delegate (Match matchToEval)
            {
                string v = matchToEval.ToString();
                return char.ToUpper(v[0]) + v.Substring(1);
            });
            Console.WriteLine("Originale: {0}", input);
            Console.WriteLine("Dopo sostituzione: {0}", result); //Una Frase Tutta In Minuscolo

            input = "12/31/2014";
            pattern = @"\b(\d{1,2})\/(\d{1,2})\/(\d{2,4})";
            replacement = "$2-$1-$3";
            result = Regex.Replace(input, pattern, replacement);
            Console.WriteLine("{0} convertita in {1}", input, result);

            pattern = @"\b(?<mese>\d{1,2})\/(?<giorno>\d{1,2})\/(?<anno>\d{2,4})";
            replacement = "${giorno}-${mese}-${anno}";
            result = Regex.Replace(input, pattern, replacement);
            Console.WriteLine("{0} convertita in {1}", input, result);
        }
    }
}
