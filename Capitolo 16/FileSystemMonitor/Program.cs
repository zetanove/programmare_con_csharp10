using System;
using System.IO;

namespace FileSystemMonitor
{
    class Program
    {
        static string source = @"C:\temp\source";
        static string target = @"C:\temp\target";

        static void Main(string[] args)
        {
            if (!Directory.Exists(source))
                Directory.CreateDirectory(source);
            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);

            Console.WriteLine("File system watcher");
            FileSystemWatcher watcher = new FileSystemWatcher(source, "*.txt");
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.Size;


            watcher.Created += watcher_Event;
            watcher.Changed += watcher_Event;
            watcher.Renamed += watcher_Event;

            //inizia il monitoraggio
            watcher.EnableRaisingEvents = true;

            Console.ReadLine();
        }

        static void watcher_Event(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                Console.WriteLine("copia di {0}", e.Name);
                FileInfo fs = new FileInfo(e.FullPath);
                fs.CopyTo(Path.Combine(target, Path.GetFileName(e.FullPath)), true);
            }
        }

    }
}
