
class Program
{
    static void Main()
    {
        string path = "c:\\temp\\file.txt";

        using (Stream s = new FileStream(path, FileMode.OpenOrCreate))
        {
            s.Write(new byte[] { 1 }, 0, 1);
        }

        using StreamReader sr1 = File.OpenText(path);
        string line;
        while ((line = sr1.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
        sr1.Close();

        using StreamReader sr = File.OpenText(path) ;
        string str = sr.ReadToEnd();
        
    }
}
