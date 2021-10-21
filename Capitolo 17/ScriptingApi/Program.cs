using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptingApi
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var result = await CSharpScript.EvaluateAsync("1 + 2");
            Console.WriteLine(result); // 1 + 2 sarà valutato come 3

            double d = await CSharpScript.EvaluateAsync<double>("5/(3-1)*3.5");
            Console.WriteLine(d); // 7

            var sum = await CSharpScript.EvaluateAsync("int x=1; int y=2; int z=x+y; z");
            Console.WriteLine(sum); // 3

            try
            {
                await CSharpScript.EvaluateAsync("1+a");
            }
            catch (CompilationErrorException e)
            {
                Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics)); //stampa gli errori di compilazione
            }

            var state = await CSharpScript.RunAsync("int x=0;int y=x+1; y");
            ScriptVariable y = state.Variables.First(sv => sv.Name == "y");
            var returnVal = state.ReturnValue;


            ScriptOptions scriptOptions = ScriptOptions.Default;
            var systemCore = typeof(System.Linq.Enumerable).Assembly;
            //Aggiunge riferimento
            scriptOptions = scriptOptions.AddReferences(systemCore);
            //Aggiunge namespaces
            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Linq");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");

            var state1 = await CSharpScript.RunAsync(@"var list = new List<int>(){1,2,3,4,5};", scriptOptions);
            state1 = await state1.ContinueWithAsync("var sum = list.Sum();");
            var sum1 = state1.Variables.FirstOrDefault(v => v.Name == "sum");
            Console.WriteLine($"sum={sum1.Value}");

        }
    }
}
