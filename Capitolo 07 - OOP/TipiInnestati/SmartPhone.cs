using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipiInnestati
{
    public class SmartPhone
    {
        private string modello;

        protected internal Battery battery;

        protected internal class Battery
        {
            private SmartPhone phone;
            internal Battery(SmartPhone phone)
            {
                this.phone = phone;
                
            }

            public string Modello
            {
                get
                {
                    return "Batteria per modello " + phone.modello;
                }
            }

            public LivelloBatteria Livello
            {
                get
                {
                    if (PercentualeCarica == 0)
                        return LivelloBatteria.zero;
                    else if (PercentualeCarica < 30)
                        return LivelloBatteria.basso;
                    else if (PercentualeCarica < 60)
                        return LivelloBatteria.medio;
                    else if (PercentualeCarica < 99)
                        return LivelloBatteria.alto;
                    else return LivelloBatteria.totale;

                }
            }


            public double PercentualeCarica { get; set; }

            public enum LivelloBatteria { zero, basso, medio, alto, totale }
        }
    }

    public class NewSmartphone:SmartPhone
    {
        public NewSmartphone()
        {
            this.battery = new Battery(this);
        }
    }

}
