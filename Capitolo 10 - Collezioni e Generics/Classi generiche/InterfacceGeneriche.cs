/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: interfacce generiche
 */


namespace Classi_generiche
{
    //interfaccia generica
    public interface ITransformer<T, S>
    {
        S Transform(T param1);
    }

    class Transformer<T, S> : ITransformer<T, S>
    {
        public S Transform(T param1)
        {
            return default(S);
        }
    }

    class TransformerIntString : ITransformer<int, string>
    {
        public string Transform(int param1)
        {
            return param1.ToString();
        }
    }

    class TransformerIntStringInt : ITransformer<int, string>, ITransformer<string, int>
    {
        public string Transform(int param1)
        {
            return param1.ToString();
        }
        public int Transform(string param1)
        {
            int val;
            if (int.TryParse(param1, out val))
                return val;
            return default(int);
        }
    }
}
