/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti * 
 * Appendice B: Unsafe Code
 */
using System;
using System.Runtime.InteropServices;

namespace UnsafeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            NativeMethods.MessageBox(IntPtr.Zero, "test", "test cap", 0);
           

            unsafe
            {
                int i = 123;

                int* pInt1 = &i;
                int* pInt2;
                pInt2 = pInt1;

                Console.WriteLine("{0} {1}", *pInt1, *pInt2);

                *pInt1 = 456;
                Console.WriteLine("{0} {1}", *pInt1, *pInt2);

                Coords<int>* pCoords; //da C# 8 in poi
                CoordsU<int>* pCoordsU;
            }
        }
    }

    public unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;
    }

    public struct Coords<T>
    {
        public T X;
        public T Y;
    }

    public struct CoordsU<T> where T : unmanaged //da C# 7.3 in poi
    {
        public T X;
        public T Y;
    }

    class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);
    }
}
