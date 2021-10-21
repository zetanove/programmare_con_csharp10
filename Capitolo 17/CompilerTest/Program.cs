using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace CompilerTest
{
    class Program
    {
        private const string code = @"using System;
                using System.Collections;
                using System.Linq;
                using System.Text;

                namespace HelloWorld
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            Console.WriteLine(""Hello, World!"");
                        }
                    }
                }";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            foreach (var us in root.Usings)
            {
                Console.WriteLine(us.ToString());
            }

            var firstMember = root.Members[0];
            var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;

            SyntaxKind kind = firstMember.Kind();

            var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
            var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
            var argsParameter = mainDeclaration.ParameterList.Parameters[0];

            Console.WriteLine($@"Il metodo {mainDeclaration.Identifier} ha il parametro {argsParameter.Identifier} di tipo {argsParameter.Type} e restituisce {mainDeclaration.ReturnType}");

            tree = CSharpSyntaxTree.ParseText(code);
            var diagnostics = tree.GetDiagnostics();

            var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>().Where(m => m.Identifier.Text.StartsWith("Method"));


            return;
        }
    }
}
