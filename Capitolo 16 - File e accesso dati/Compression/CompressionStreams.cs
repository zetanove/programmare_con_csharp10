using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    internal class CompressionStreams
    {

        private const string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private const string OriginalFileName = "miofile.txt";
        private const string CompressedFileName = "pacchetto.gz";
        private const string DecompressedFileName = "estratto.txt";

        public static void TestGZip()
        {
            ///Creo un file di testo
            File.WriteAllText(OriginalFileName, Message);


            CompressFileGZip();
            DecompressFileGZip();
            StampaRisultati();
            DeleteFiles();

        }


        private static void CompressFileGZip()
        {
            using FileStream originalFileStream = File.Open(OriginalFileName, FileMode.Open);
            using FileStream compressedFileStream = File.Create(CompressedFileName);
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
        }

        private static void DecompressFileGZip()
        {
            using FileStream compressedFileStream = File.Open(CompressedFileName, FileMode.Open);
            using FileStream outputFileStream = File.Create(DecompressedFileName);
            using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
        }

        private static void StampaRisultati()
        {
            long originalSize = new FileInfo(OriginalFileName).Length;
            long compressedSize = new FileInfo(CompressedFileName).Length;
            long decompressedSize = new FileInfo(DecompressedFileName).Length;

            Console.WriteLine($"Dimensione originale di '{OriginalFileName}': {originalSize} byte.");
            Console.WriteLine($"Dimensione file compresso '{CompressedFileName}': {compressedSize} byte.");
            Console.WriteLine($"Dimensione file estratto '{DecompressedFileName}': {decompressedSize} byte.");

            string contenutoOriginale = File.ReadAllText(OriginalFileName);
            string contenutoEstratto = File.ReadAllText(DecompressedFileName);
            Console.WriteLine($"contenuto originale ed estratto sono uguali: {contenutoOriginale.Equals(contenutoEstratto)}");
        }

        private static void DeleteFiles()
        {
            File.Delete(OriginalFileName);
            File.Delete(CompressedFileName);
            File.Delete(DecompressedFileName);
        }
    }

}
