/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: code generation
 */

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Code_Generation
{
    class Program
    {
        static void Main(string[] args)
        {

            var dynMethod = new DynamicMethod("HelloMethod", null, null);
            ILGenerator gen = dynMethod.GetILGenerator();
            gen.EmitWriteLine("Hello world");
            gen.Emit(OpCodes.Ret);
            dynMethod.Invoke(null, null);

            AssemblyName name = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder= AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave);
            
            ModuleBuilder moduleBuilder= assemblyBuilder.DefineDynamicModule("DynamicModule", "DynamicAssembly.dll");
            TypeBuilder tb= moduleBuilder.DefineType("HelloClass", TypeAttributes.Class|TypeAttributes.Public);

            MethodBuilder mb= tb.DefineMethod("PrintHello", MethodAttributes.Public, null, new Type[]{typeof(string)});

            ILGenerator myMethodIL = mb.GetILGenerator();
            myMethodIL.Emit(OpCodes.Ldstr, "Hello ");
            myMethodIL.Emit(OpCodes.Ldarg_1);
            MethodInfo concatMethod = typeof(String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
            myMethodIL.Emit(OpCodes.Call, concatMethod);
            MethodInfo writeMethod = typeof(Console).GetMethod("Write", new Type[] { typeof(string) });
            myMethodIL.Emit(OpCodes.Call, writeMethod);
            myMethodIL.Emit(OpCodes.Ret);

            Type helloType=tb.CreateType();

            object helloObj= Activator.CreateInstance(helloType);
            MethodInfo helloInstanceMethod= helloType.GetMethod("PrintHello", new Type[] { typeof(string) });
            helloInstanceMethod.Invoke(helloObj, new object[]{ "Antonio" });

            assemblyBuilder.Save("DynamicAssembly.dll");
        }
    }
}
