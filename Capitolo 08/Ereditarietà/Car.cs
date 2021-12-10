using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    class Car : StreetVehicle, ICruiseControl
    {
        protected double livelloCarburante;
        private bool motoreAcceso;
        
        public void Accendi()
        {
            if (!motoreAcceso && livelloCarburante > 0)
                motoreAcceso = true;
        }
        public void Spegni()
        {
            if (motoreAcceso)
                motoreAcceso = false;
        }

        public Car(): base(4)
        {
            livelloCarburante = 100;
           
        }

        public override void Accelerate()
        {
            Console.WriteLine("Car.Accelerate");
            if (livelloCarburante > 0 && currentSpeed < maxSpeed)
            {
                currentSpeed += 2.0;
                livelloCarburante -= currentSpeed / 10;
            }
        }


        private int? cruiseSpeed;
        public int? CruiseSpeed
        {
            get { return cruiseSpeed; }
        }

        public void ResetCruise()
        {
            cruiseSpeed=null;
        }

        public void SetCruise(int speed)
        {
            cruiseSpeed=speed;
        }

        public void StartControl()
        {
            if (currentSpeed < cruiseSpeed)
            {
                while (currentSpeed < cruiseSpeed && livelloCarburante>0)
                    Accelerate();
            }
            else
            {
                while (currentSpeed > cruiseSpeed)
                    Brake();
            }
        }
    }

    class Supercar : Car, ICruiseControl
    {
        public override void Accelerate()
        {
            base.Accelerate();
        }




        int? ICruiseControl.CruiseSpeed
        {
            get { throw new NotImplementedException(); }
        }

        void ICruiseControl.ResetCruise()
        {
            throw new NotImplementedException();
        }

        void ICruiseControl.SetCruise(int speed)
        {
            throw new NotImplementedException();
        }

        void ICruiseControl.StartControl()
        {
            throw new NotImplementedException();
        }
    }

    class Sedan : ICruiseControl
    {
        int? ICruiseControl.CruiseSpeed
        {
            get { return null; }
        }

        void ICruiseControl.ResetCruise()
        {
        }

        void ICruiseControl.SetCruise(int speed)
        {
        }

        void ICruiseControl.StartControl()
        {

        }
    }

}
