/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: direttive preprocessore
 */


using System;


//modifica la configurazione di compilazione per utilizzare i simboli
#if DEBUG
    Console.WriteLine("modo debug");
#elif RELEASE
    Console.WriteLine("modo release");
#else
    Console.WriteLine("debug e release non definite");
#endif

#if SYM1  //definite nel file di progetto
    Console.WriteLine("SYM1");
#endif
