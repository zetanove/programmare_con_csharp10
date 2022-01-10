using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class GiriMotoreEventArgs : EventArgs
    {
        public int NumeroGiriRaggiunto { get; set; }
    }

    public class Car
    {
        delegate void GiriMotoreEventHandler(GiriMotoreEventArgs args);
        //public event GiriMotoreEventHandler MotoreFuoriGiriEvent;

        public event EventHandler<GiriMotoreEventArgs> MotoreFuoriGiri;
        public event EventHandler MotoreSpento;

        private EventHandler _motoreAcceso;
        public event EventHandler MotoreAcceso
        {
            add
            {
                _motoreAcceso += value;
            }
            remove
            {
                _motoreAcceso -= value;
            }
        }

        private int numeroGiri;
        public bool EngineOn { get; set; }

        public void Start()
        {
            numeroGiri = 800;
            EngineOn = true;
            OnMotoreAcceso();
        }

        private void OnMotoreAcceso()
        {
            if (_motoreAcceso != null)
                _motoreAcceso(this, EventArgs.Empty);
        }

        public void Accelerate()
        {
            if (EngineOn)
            {
                numeroGiri += 100;
                if (numeroGiri > 8000)
                {
                    OnFuoriGiri();
                }
            }
        }

        public virtual void Decelerate()
        {
            if (!EngineOn)
                return;
            numeroGiri -= 100;
            if (numeroGiri <= 300)
            {
                numeroGiri = 0;
                EngineOn = false;
                OnMotoreSpento();
            }
        }

        protected virtual void OnMotoreSpento()
        {
            if (MotoreSpento != null)
            {
                MotoreSpento(this, EventArgs.Empty);
            }
        }

        private void OnFuoriGiri()
        {
            if (MotoreFuoriGiri != null)
            {
                MotoreFuoriGiri(this, new GiriMotoreEventArgs() { NumeroGiriRaggiunto = this.numeroGiri });
            }
        }

    }

    public class ElectricCar : Car
    {
        protected override void OnMotoreSpento()
        {
            base.OnMotoreSpento();
        }
    }

    public class CarMonitor
    {
        public CarMonitor(Car car)
        {
            car.MotoreSpento += car_MotoreSpento;
            car.MotoreFuoriGiri += car_MotoreFuoriGiri;
            car.MotoreAcceso += car_MotoreAcceso;
            
        }

        void car_MotoreAcceso(object sender, EventArgs e)
        {
            Console.WriteLine("il motore è acceso");
        }

        void car_MotoreFuoriGiri(object sender, GiriMotoreEventArgs e)
        {
            Console.WriteLine("Fuori giri: " + e.NumeroGiriRaggiunto);
            
        }

        void car_MotoreSpento(object sender, EventArgs e)
        {
            Car car = sender as Car;
            Console.WriteLine("Il motore si è spento");
            //car.Start();
        }
    }
}
