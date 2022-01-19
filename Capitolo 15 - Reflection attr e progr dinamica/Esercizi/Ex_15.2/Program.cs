/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: 
 * Esercizio 2)
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string processName = "Hello2";
            AssemblyBuilder assemblyBuilder2 = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName() { Name = processName }, AssemblyBuilderAccess.Save);
            ModuleBuilder moduleBuilder2 = assemblyBuilder2.DefineDynamicModule(processName, processName + ".EXE");
            TypeBuilder typeBuilder = moduleBuilder2.DefineType("Program", TypeAttributes.Public);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.Static, null, null);
            ILGenerator il = methodBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Hello World");
            MethodInfo writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            il.Emit(OpCodes.Call, writeLineMethod);
            il.Emit(OpCodes.Ret);
            typeBuilder.CreateType();
            assemblyBuilder2.SetEntryPoint(methodBuilder.GetBaseDefinition(), PEFileKinds.ConsoleApplication);
            assemblyBuilder2.Save(processName + ".EXE", PortableExecutableKinds.Required32Bit, ImageFileMachine.I386);
        }

        
    }
}
