/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 11:
 * Esercizio 1)
 */
 
 using System;

namespace Esercizio1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Online_Application
    {
        class Program
        {
            static void Main(string[] args)
            {
                EnterName ename = new EnterName();
                ename.ev_BannedUser += WarningAlarm;
                ename.User();
                Console.Read();
            }
            static void WarningAlarm(object sender, BannedUserEventArgs e)
            {
                Console.WriteLine("{0} Utente bloccato.", e.Name);
                Console.WriteLine("Warning Alarm Started.");
                Console.WriteLine("Press Ctrl + c to stop the alarm");
                for (; ; )
                {
                    Console.Beep();
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        public class EnterName
        {
            public event EventHandler<BannedUserEventArgs> ev_BannedUser;
            public void User()
            {
                Console.Write("Come ti chiami? ");
                string user = Console.ReadLine();

                if ((user == "Antonio" || user == "Matilda")  && (ev_BannedUser != null))
                {
                    ev_BannedUser(this, new BannedUserEventArgs(user));
                }
                else
                {
                    Console.WriteLine("Benvenuto " + user);
                }
            }
        }

        public class BannedUserEventArgs : EventArgs
        {
            public BannedUserEventArgs(string s)
            {
                Name = s;
            }
            public string Name { get; set; }
        }
    }
}
