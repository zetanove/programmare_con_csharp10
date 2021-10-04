using System;


namespace Metodi
{
    class Uomo
    {
        public int altezza = 170;
    }

    class Program
    {
        static void CambiaAltezza(Uomo uomo)
        {
            Console.WriteLine("prima dell'assegnazione: {0}", uomo.altezza);
            uomo.altezza = 180;
            Console.WriteLine("dopo l'assegnazione: {0}", uomo.altezza);
        }

        static void CambiaAltezza2(Uomo uomo)
        {
            Console.WriteLine("prima dell'assegnazione: {0}", uomo.altezza);
            uomo = new Uomo();
            uomo.altezza = 180;
            Console.WriteLine("dopo l'assegnazione: {0}", uomo.altezza);
        }

        static void CambiaAltezza2(ref Uomo uomo)
        {
            Console.WriteLine("prima dell'assegnazione: {0}", uomo.altezza);
            uomo = new Uomo();
            uomo.altezza = 180;
            Console.WriteLine("dopo l'assegnazione: {0}", uomo.altezza);
        }

        static void CambiaAltezza3(in Uomo uomo)
        {
            Console.WriteLine("prima dell'assegnazione: {0}", uomo.altezza);
            uomo.altezza = 123;
            Console.WriteLine("dopo l'assegnazione: {0}", uomo.altezza);
        }

        static void PotenzeMultiple(int val, out int potenza2, out int potenza3)
        {
            potenza2 = val * val;
            potenza3 = potenza2 * val;
        }

        static double CalcolaMedia(params double[] array)
        {
            double media = 0;
            for (int i = 0; i < array.Length; i++)
            {
                media += array[i];
            }
            return media / array.Length;
        }

        static int Optional(int a = 0, int b = 1)
        {
            return a + b;
        }

        void StampaValore(int i = default)
        {
            Console.WriteLine(i);
        }

        //usato per esempio parametri denominati e posizionali
        static int MioMetodo(int a, int b, int c)
        {
            return a + b + c;
        }

        static void Main(string[] args)
        {
            double numero = 2;
            int esponente = 4;
            Calcolatore calc = new Calcolatore();
            Console.WriteLine("numero={0}, esponente={1}", numero, esponente);
            double risultato = calc.Potenza(numero, esponente);
            Console.WriteLine("{0}^{1}={2}", numero, esponente, risultato);
            Console.WriteLine("numero={0}, esponente={1}, risultato={2}", numero, esponente, risultato);

            int i = 1;
            calc.PassByValue(i);
            Console.WriteLine("i={0}", i);

            calc.PassByRef(ref i);
            Console.WriteLine("i={0}", i);

            Uomo uomo = new Uomo();
            Console.WriteLine("prima del metodo: {0}", uomo.altezza);
            CambiaAltezza(uomo);
            Console.WriteLine("dopo metodo: {0}", uomo.altezza);

            uomo = new Uomo();
            Console.WriteLine("prima del metodo: {0}", uomo.altezza);
            CambiaAltezza2(uomo);
            Console.WriteLine("dopo metodo: {0}", uomo.altezza);

            uomo = new Uomo();
            Console.WriteLine("prima del metodo: {0}", uomo.altezza);
            CambiaAltezza2(ref uomo);
            Console.WriteLine("dopo metodo: {0}", uomo.altezza);

            uomo = new Uomo();
            Console.WriteLine("prima del metodo: {0}", uomo.altezza);
            CambiaAltezza3(uomo);
            Console.WriteLine("dopo metodo: {0}", uomo.altezza);

            int p3;
            PotenzeMultiple(4, out int p2, out p3); //p2 è dichiarata inline

            //discard
            if(int.TryParse("123", out _))
            {
                Console.WriteLine("è un intero, ma lo scarto");
            }

            if (int.TryParse("123", out int _))
            {
                Console.WriteLine("è un intero, ma lo scarto");
            }


            _ = int.TryParse("123", out int valIntero);

            double media = CalcolaMedia(1, 2, 3.4, 6, 9.2);
            media = CalcolaMedia(new double[] { 2, 4, 5.9, 33.9 });
            double d = CalcolaMedia();

            int sum = Optional(1);
            sum = Optional(b: 2);

            int somma = calc.Somma(2, 3);

            somma = MioMetodo(a: 1, 2, c: 3);


            Ricorsione ric = new Ricorsione();
            var fatt = ric.Fattoriale(5);

            LocalFunction lf = new LocalFunction();
            lf.Demo();
            Console.WriteLine(fatt);

            TestRefReturnLocal testRef = new TestRefReturnLocal();
            testRef.PrintNumbers();
            ref int number = ref testRef.FindNumber(7);
            number = 123; //modifico il riferimento
            testRef.PrintNumbers();


            number = ref testRef.FindNumber(15); //local ref reassign

            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };
            int val = array[1];
            val = 999;
            Console.WriteLine(array[1]); //non cambia valore

            ref int refVal = ref array[1];
            refVal = 999;
            Console.WriteLine(array[1]); //cambia valore

            refVal = ref array2[1];
            Console.WriteLine(refVal); 
            refVal = 999;
            Console.WriteLine(array[1]); //cambia valore nell'array2
        }
    }
}
