/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 16: 
 * Esercizio 2)
 */

using System;
using System.IO;

namespace Ex_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il percorso della cartella da analizzare:");
            var folder = Console.ReadLine();

            if(Directory.Exists(folder))
            {
                RecurseFolder(folder, 0);
            }
        }

        private static void RecurseFolder(string folder, int level)
        {
            DirectoryInfo diTemp = new DirectoryInfo(folder);
            
            var files = diTemp.EnumerateFiles();

            foreach (FileInfo finfo in files)
            {
                Console.WriteLine(new string(' ', level * 3) + "{0, -30} - {1}KB", finfo.Name, finfo.Length >> 10);
            }

            var entries = diTemp.EnumerateDirectories();
            foreach (FileSystemInfo fsi in entries)
            {
                Console.WriteLine(new string(' ', level * 3) + fsi.Name);
                RecurseFolder(fsi.FullName, ++level);
            }
        }
    }
}
