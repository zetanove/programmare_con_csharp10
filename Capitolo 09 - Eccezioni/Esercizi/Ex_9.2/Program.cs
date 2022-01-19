using System;

namespace Ex_9._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1,2,3,4,5 };

            try
            {
                Console.WriteLine(array[10]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
