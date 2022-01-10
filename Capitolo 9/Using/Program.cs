using System;
using System.IO;

namespace Using
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingStatement();
            UsingDeclaration();
        }

        public static void UsingStatement()
        {
            Console.WriteLine("Istruzione using");
            string path = @"C:\Windows\win.ini"; //inserire il percorso di un file esistente
            using (StreamReader stream = File.OpenText(path))
            {
                string content = stream.ReadToEnd();
                Console.WriteLine($"Contenuto del file {path}: {content}");
            } //Dispose di stream
                        
        }


        public static void UsingDeclaration()
        {
            Console.WriteLine("Using Declaration");
            string path = @"C:\Windows\win.ini"; //inserire il percorso di un file esistente
            using StreamReader stream = File.OpenText(path);
            string content = stream.ReadToEnd();
            Console.WriteLine($"Contenuto del file {path}: {content}");
        }//Dispose di stream
    }
}
