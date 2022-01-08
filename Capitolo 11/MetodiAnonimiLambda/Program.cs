
using System.Linq.Expressions;

namespace MetodiAnonimiLambda
{
    class Program
    {
        delegate bool CheckIntDelegate(int i);
        static void Main(string[] args)
        {
            List<int> lista = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            List<int> numeripari = lista.FindAll(delegate (int i) {
                return i % 2 == 0;
            });
            numeripari.ForEach(Console.WriteLine);

            //lambda
            CheckIntDelegate del = (x => x % 2 == 0);
            var pari = del(234);

            Predicate<int> pred = (x => x % 2 == 0);
            bool b = pred(234521);

            var dispari = lista.FindLast(i => i % 2 != 0);

            Func<int, int, double> mediaFunc = (x, y) => (x + y) / 2.0;
            double average = mediaFunc(3, 7);

            Action<string, string> upperAction = (s1, s2) =>
            {
                string s = s1 + " " + s2;
                Console.WriteLine(s.ToUpper());
            };

            upperAction("Hello", "World");

            //variabili catturata
            Func<int, int> func = CreaFunc();
            int res = func(5);

            //modifica variabile catturata
            Func<int> modificaVariabile = () => res = 10;
            modificaVariabile();
            Console.WriteLine(res);


            Expression<Func<int, bool>> exprPari = num => num % 2 == 0;

            // Compila l'abero di espression in delegate.
            Func<int, bool> isPari = exprPari.Compile();

            // invoca il delegate 
            Console.WriteLine(isPari(4));


            // sintassi semplificata
            Console.WriteLine(exprPari.Compile()(5));

            //analizzare l'espressione
            ParameterExpression parNum = exprPari.Parameters[0];
            BinaryExpression opModulo = (BinaryExpression)exprPari.Body;
            BinaryExpression exprLeft = (BinaryExpression)opModulo.Left;
            ParameterExpression exprNum = (ParameterExpression)exprLeft.Left;
            ConstantExpression expr2 = (ConstantExpression)exprLeft.Right;
            ConstantExpression opRight = (ConstantExpression)opModulo.Right;

        }

        //
        public static Func<int, int> CreaFunc()
        {
            int factor = 5;
            Func<int, int> multiply = x => x * factor; //factor variabile catturata
            return multiply;
        }

    }
}
