using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    public abstract class FlyingVehicle: Vehicle
    {
        protected short directionDegrees;
        protected int altitude;

        public FlyingVehicle()
        {
            altitude = 0;
            directionDegrees = 0;
        }

        public virtual void TakeOff()
        {
            if (altitude == 0)
                Console.WriteLine("Take off!");
        }

        public virtual void Land()
        {
            if(altitude>0)
                Console.WriteLine("Landed!");
        }
    }

    public abstract class SpaceVehicle: FlyingVehicle
    {
        public abstract void Launch();
    }
}
