using System;
using System.IO;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File system!");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drives)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine("	File type: {0}", driveInfo.DriveType);
                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine("  File system:				 {0}", driveInfo.DriveFormat);
                    Console.WriteLine("  Spazio disponibile:  {0,10} KBytes", (driveInfo.AvailableFreeSpace >> 10));
                    Console.WriteLine("  Spazio totale:		   {0,10} KBytes", driveInfo.TotalFreeSpace >> 10);
                    Console.WriteLine("  Total size of drive: {0,10} KBytes", driveInfo.TotalSize >> 10);
                }
            }


            string dirname = @"C:\temp";
            string filename = "file.txt";
            string fullpath = Path.Combine(dirname, filename); //C:\\temp\\file.txt"
            string xml = Path.ChangeExtension(filename, "xml");// file.xml
            string dir = Path.GetDirectoryName(fullpath); // c:\temp
            string ext = Path.GetExtension(fullpath); // .txt
            string file = Path.GetFileName(fullpath); // file.txt
            string filewithoutext = Path.GetFileNameWithoutExtension(fullpath); // file

            Directory.SetCurrentDirectory("c:\\windows"); //imposta la directory di lavoro corrente
            string full = Path.GetFullPath(filename); // c:\windows\file.txt

            string root = Path.GetPathRoot(fullpath); // C:
            bool hasExt = Path.HasExtension("file.txt"); // true
            bool pathRooted = Path.IsPathRooted("c:\\file.txt"); //true

            string randomFile = Path.GetRandomFileName(); // v3ybhjqf.0xd
            string tempFile = Path.GetTempFileName(); // C:\Users\UserName\AppData\Local\Temp\tmp210E.tmp
            string tempPath = Path.GetTempPath(); // C:\Users\UserName\AppData\Local\Temp

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            //file e directory
            DirectoryInfo tempDir = new DirectoryInfo("c:\\temp\\tempdir");
            if (tempDir.Exists)
                tempDir.Delete(true);

            if (Directory.Exists("c:\\temp\\tempdir"))
                Directory.Delete("c:\\temp\\tempdir", true);



            bool exists = File.Exists(fullpath);
            FileInfo fi1 = new FileInfo(fullpath);
            exists = fi1.Exists;

        }
    }
}
