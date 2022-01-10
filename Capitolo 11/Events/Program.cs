using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {


        static void Main()
        {


            Car car = new Car();
            CarMonitor monitor = new CarMonitor(car);
            car.Start();
            while (car.EngineOn)
                car.Decelerate();

            car.Start();
            for (int i = 0; i < 100; i++)
                car.Accelerate();

            ElectricCar ec = new ElectricCar();
            ec.Start();
            while (ec.EngineOn)
                ec.Decelerate();

            Moto moto = new Moto();
            moto.Event1 += moto_Event1;
            moto.RaiseEvent1();
            moto.Event1 -= moto_Event1;

           
        }

        static void moto_Event1(object sender, EventArgs e)
        {
            Console.WriteLine("moto_Event1");
        }

 
    }
}
