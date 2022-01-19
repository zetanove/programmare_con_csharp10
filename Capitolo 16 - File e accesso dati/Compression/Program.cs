

using Compression;
using System.IO.Compression;
/**
* File zip
* Programmare con C# 10
* Antonio Pelleriti
*/
class Program
{
    static void Main(string[] args)
    {
        string startPath = "C:\\temp\\start";
        string zipPath = "C:\\temp\\archivio.zip";
        string extractPath = @"C:\\temp\\extract";

        if (File.Exists(zipPath))
            File.Delete(zipPath);
        if (Directory.Exists(extractPath))
            Directory.Delete(extractPath, true);

        ZipFile.CreateFromDirectory(startPath, zipPath);

        ZipFile.ExtractToDirectory(zipPath, extractPath);

        //aprire e leggere gli elementi in un file zip
        using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Read))
        {
            foreach (ZipArchiveEntry entry in zip.Entries)
                Console.WriteLine($"{entry.FullName} {entry.Length} byte");
        }


        using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
        {
            ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
            {
                writer.WriteLine("questo è nuovo file.");
            }
        }


        //Stream
        CompressionStreams.TestGZip();

    }
}