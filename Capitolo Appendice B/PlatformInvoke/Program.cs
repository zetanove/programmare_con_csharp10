using System;
using System.Runtime.InteropServices;

namespace PlatformInvoke
{
    class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int
        options);
    }

    class Program
    {
        static void Main(string[] args)
        {
            NativeMethods.MessageBox(IntPtr.Zero, "World", "Hello", 0);
        }
    }
}
