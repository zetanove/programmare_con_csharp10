namespace Switch
{


    public class Persona
    {
        public string NomeCognome { get; set; }
        public DateTime DataNascita { get; set; }

        public Persona Padre { get; set; }

        public Persona Madre { get; set; }

        public bool TestPropertyRicorsiva(object p)
        {
            return p is Persona { DataNascita.Year: < 2000, Madre: { DataNascita.Month: 1 or 2 or 3 }, Padre: { NomeCognome.Length: > 10 } };
        }

        public void TestSwitch(object obj)
        {
            switch(obj)
            {
                
                case Persona { 
                    DataNascita.Year: < 2000, 
                    Madre: { 
                        DataNascita.Month: 1 or 2 or 3 
                    }, 
                    Padre: { 
                        NomeCognome.Length: > 10 
                    } ,

                }:

                    Console.WriteLine("pattern ricorsivo");
                        break;

                case not null:
                    {
                        break;
                    }

                case var _:
                    {
                        break;
                    }

                
            }
        }
    }
}

