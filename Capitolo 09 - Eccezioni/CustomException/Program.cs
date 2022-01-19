/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: eccezioni custom
 */
using System;
using System.IO;

namespace CustomException
{
    class MotorVehicle
    {
        public string Targa { get; set; }
        public double LivelloCarburante { get; set; }
    }

    class Car : MotorVehicle
    {
        public Car(string targa)
        {
            Targa = targa;
            LivelloCarburante = 10;
        }
        public void Accelera()
        {
            if (LivelloCarburante == 0)
                throw new NoFuelException(this);
            else
            {
                Console.WriteLine("vroooooom!!!");
                LivelloCarburante -= 1;
            }
        }

        public void Spegni()
        {
            Console.WriteLine("Stop!");
        }
    }

    class NoFuelException : InvalidOperationException
    {
        public MotorVehicle Vehicle { get; set; }

        public NoFuelException()
        {
        }

        public NoFuelException(string message) : base(message)
        {
        }

        public NoFuelException(string message, Exception inner) : base(message, inner)
        {
        }

        public NoFuelException(MotorVehicle vehicle) : this("non c'è più benzina")
        {
            Vehicle = vehicle;
        }
    }

    class MyIOException : IOException
    {
    }


    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("CP787MC") { LivelloCarburante = 5 };
            try
            {
                while (true)
                {
                    car.Accelera();
                }
            }
            catch (NoFuelException ex)
            {
                Console.WriteLine("Il veicolo targato {0} non può accelerare: {1}", ex.Vehicle.Targa, ex.Message);
            }
            finally
            {
                car.Spegni();
            }
        }

    }
}
