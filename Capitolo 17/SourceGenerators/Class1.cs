using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Text;

namespace MyGenerator
{
    [Generator]
    public class MySourceGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            // build up the source code
            StringBuilder sourceBuilder = new StringBuilder();

            sourceBuilder.Append($@"
                using System;

                namespace {mainMethod.ContainingNamespace.ToDisplayString()}
                {{
                    public static partial class {mainMethod.ContainingType.Name}
                    {{
                        static partial void HelloFrom(string name)
                        {{
                            Console.WriteLine($""Sono un source generator: Ciao da '{{name}}'"");
                            
                        }}
                    }}
                }}
                ");

            // add the source code to the compilation
            context.AddSource("generatedSource", sourceBuilder.ToString());


            //var sourceBuilder = new StringBuilder(@"
            //    using System;
            //    namespace {mainMethod.ContainingNamespace.ToDisplayString()}
            //    {
            //        public static partial class HelloWorld
            //        {
            //            public static void SayHello() 
            //            {
            //                Console.WriteLine(""Hello from generated code!"");
            //                Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
            //    ");

            //// using the context, get a list of syntax trees in the users compilation
            //var syntaxTrees = context.Compilation.SyntaxTrees;

            //// add the filepath of each tree to the class we're building
            //foreach (SyntaxTree tree in syntaxTrees)
            //{
            //    sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
            //}

            //// finish creating the source to inject
            //sourceBuilder.Append(@"
            //            }
            //        }
            //    }");

            //// inject the created source into the users compilation
            //context.AddSource("helloWorldGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }


        public void Initialize(GeneratorInitializationContext context)
        {
            //throw new NotImplementedException();
        }
    }
}