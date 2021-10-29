

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

        ZipFile.CreateFromDirectory(startPath, zipPath);

        ZipFile.ExtractToDirectory(zipPath, extractPath);
    }
}