using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace REPL
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var options = new CSharpParseOptions(LanguageVersion.CSharp8,
                DocumentationMode.Parse, SourceCodeKind.Script, null);

            Script<object> script = CSharpScript.Create(string.Empty);
            Console.Write("C# 8 REPL (inserisci :q per uscire)");
            while (true)
            {
                Console.Write("> ");
                var code = Console.ReadLine();
                var newScript = script.ContinueWith(code);

                ScriptState<object> result = null;
                try
                {
                    bool isComplete = IsCompleteSubmission(code);
                    if (code == ":q")
                        break;
                    else if (!isComplete)
                        Console.WriteLine("Istruzione incompleta");
                    else
                    {
                        result = await newScript.RunAsync();
                        script = newScript;
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    WriteError(error);
                }

                if (result != null && result.ReturnValue != null)
                    Console.WriteLine(result.ReturnValue);

                static void WriteError(string error)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error);
                    Console.ForegroundColor = color;
                }

                bool IsCompleteSubmission(string code)
                {
                    var syntaxTree = SyntaxFactory.ParseSyntaxTree(code, options: options);
                    return SyntaxFactory.IsCompleteSubmission(syntaxTree);
                }
            }  
        }

        
    }
}
