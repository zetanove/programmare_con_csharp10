using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public interface IVehicle
    {
        event EventHandler MotoreSpento;
        event EventHandler<GiriMotoreEventArgs> MotoreFuoriGiri;
    }

    public class Moto : IVehicle
    {
        public event EventHandler MotoreSpento;

        public event EventHandler<GiriMotoreEventArgs> MotoreFuoriGiri;

        public Dictionary<string, Delegate> eventTable;
        
        public Moto()    
        {
                eventTable = new Dictionary<string, Delegate>();
                eventTable.Add("Event1", null);
        }

        public event EventHandler Event1
        {
            add
            {
                lock (eventTable)
                {                    
                    eventTable["Event1"] = (EventHandler)eventTable["Event1"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler)eventTable["Event1"] - value;
                }
            }
        }


        internal void RaiseEvent1()
        {
            EventHandler handler = eventTable["Event1"] as EventHandler;
            if(handler!=null)
                handler(this, EventArgs.Empty);
        }
    }
}
