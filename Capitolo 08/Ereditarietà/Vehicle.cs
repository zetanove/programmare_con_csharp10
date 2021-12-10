using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    public class Vehicle
    {
        protected string color="red";
        private short yearBuilt;
        private int numberOfPassengers;
        protected double maxSpeed=100;
        protected double currentSpeed;

        public string ModelName { get; set; }

        

        public double MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }
        public virtual void Accelerate()
        {
            Console.WriteLine("Vehicle acceleration");
            if (currentSpeed < maxSpeed)
                currentSpeed += 1.0;
        }
        public void Brake()
        {
            if (currentSpeed > 0)
                currentSpeed -= 1.0;
        }

        public void PrintInfo()
        {
            Console.WriteLine("{0}: current speed: {1}", ModelName, currentSpeed);
        }
    }


}
