/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: custom attributes
 */

using CustomAttributes;
using GenericAttributes;
using System;
using System.Linq;
using System.Reflection;

namespace Custom_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Vehicle);
            bool defined = t.IsDefined(typeof(VehicleTypeAttribute), false);


            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes();
            foreach (Attribute attr in attributes)
            {
                Console.WriteLine(attr.GetType().Name);
            }


            GenericVehicle gen = new GenericVehicle();
            var vattrs =gen.GetType().GetCustomAttributes(typeof(VehicleTypeAttribute), true).FirstOrDefault() as VehicleTypeAttribute;

            var attrs = typeof(GenericVehicle).GetCustomAttributes(typeof(Attr<string>));

        }
    }

    [VehicleType("Auto", Potenza = 100)]
    class Vehicle
    {

    }

   

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    sealed class VehicleTypeAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string typeDescription;

        // This is a positional argument
        public VehicleTypeAttribute(string typeDescription)
        {
            this.typeDescription = typeDescription;

            // TODO: Implement code here

        }

        public string TypeDescription
        {
            get { return typeDescription; }
        }

        // This is a named argument
        public int Potenza { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method| AttributeTargets.Field | AttributeTargets.ReturnValue)]
    class HelpAttribute : Attribute
    {
        public string HelpText { get; set; }

    }

    [Serializable]
   
    public class TestClass
    {
        [field: NonSerialized]
        public string MioCampoSegreto { get; set; }

        [method: Help, Obsolete]
        public int method()
        {
            return 0;
        }
    }

}
