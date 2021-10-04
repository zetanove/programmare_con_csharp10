using System;

namespace Varianza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Car ferrari = new Car();
            Vehicle vehicle = ferrari; //assegnazione compatibile

            Car[] carArray = new Car[10]; 
            carArray[0] = ferrari;
                       
            Vehicle[] vehicleArray = carArray; //array covarianza

            vehicleArray[1] = new Moto(); //errore
        }
    }

    class Vehicle
    {
    }

    class Car : Vehicle
    {
    }

    class Moto : Vehicle
    { }

}
