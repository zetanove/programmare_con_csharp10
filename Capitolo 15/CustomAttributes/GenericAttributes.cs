using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAttributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Attr<T> : Attribute { }

    public class VehicleTypeAttribute<T> : Attribute where T : Vehicle, new()
    {
    }

    [VehicleType<Car>]
    [Attr<string>]
    public class GenericVehicle
    {
        [Attr<string>]
        [Attr<object>]
        //[Attr<T>] // error
        void M() { }
    }

    public abstract class Vehicle 
    {}

    public class Car: Vehicle
    {

    }
}
