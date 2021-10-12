using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class F1Team
    {
        public string TeamName { get; set; }
        public Pilot[] Pilots { get; set; }
        public int Wins { get; set; }

        public override string ToString()
        {
            return String.Format("Team {0}, Wins: {1}", TeamName, Wins);
        }
    }

    class Pilot
    {
        public F1Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDCountry { get; set; }
        public int Points { get; set; }
    }

    class Country
    {
        public int IDCountry { get; set; }
        public string Name { get; set; }

        public static List<Country> All = new List<Country>(
            new Country[]
                 {
                    new Country(){IDCountry=1, Name="Spagna"},
                    new Country(){IDCountry=2, Name="Brasile"},
                    new Country(){IDCountry=3, Name="Germania"},
                    new Country(){IDCountry=4, Name="Francia"},
                    new Country(){IDCountry=5, Name="Regno Unito"},
                    new Country(){IDCountry=6, Name="Messico"},
                    new Country(){IDCountry=7, Name="Finlandia"},
                    new Country(){IDCountry=8, Name="Svizzera"},
                    new Country(){IDCountry=9, Name="Italia"},
                    new Country(){IDCountry=10, Name="USA"},
                    new Country(){IDCountry=11, Name="Monaco"},
                    new Country(){IDCountry=12, Name="Paesi Bassi"}
                 }
            );
    }


    class F1Data
    {
        public static List<F1Team> GetTeams()
        {
            List<F1Team> teams = new List<F1Team>();
            teams.Add(
                new F1Team()
                {
                    TeamName = "Ferrari",
                    Wins = 7,
                    Pilots = new Pilot[]
                    {
                        new Pilot() { FirstName="Sebastian", LastName="Vettel", IDCountry=3, Points=20 },
                        new Pilot() { FirstName="Charles", LastName="Leclerc", IDCountry=11, Points=142 }
                    }
                }
            );
            teams.Add(
                new F1Team()
                {
                    TeamName = "Mercedes",
                    Wins = 5,
                    Pilots = new Pilot[2]
                    {
                        new Pilot() { FirstName="Valtteri", LastName="Bottas",IDCountry=7, Points=52 },
                        new Pilot() { FirstName="Lewis", LastName="Hamilton", IDCountry=5, Points=77 }
                    }
                });

            teams.Add(
                new F1Team()
                {
                    TeamName = "Red Bull",
                    Wins = 2,
                    Pilots = new Pilot[2]
                    {
                        new Pilot() { FirstName="Max", LastName="Verstappen", IDCountry=12, Points=28 },
                        new Pilot() { FirstName="Pierre", LastName="Gasly", IDCountry=4, Points=23 }
                    }
                });

            teams.Add(
                new F1Team()
                {
                    TeamName = "McLaren",
                    Wins = 1,
                    Pilots = new Pilot[2]
                    {
                        new Pilot() { FirstName="Carlos", LastName="Sainz", IDCountry=1, Points=30 },
                        new Pilot() { FirstName="Lando", LastName="Norris", IDCountry=5, Points=1 }
                    }
                });

            teams.Add(
                new F1Team()
                {
                    TeamName = "Alfa Romeo",
                    Wins = 0,
                    Pilots = new Pilot[2]
                    {
                        new Pilot() { FirstName="Kimi", LastName="Raikkonen", IDCountry=7, Points=3 },
                        new Pilot() { FirstName="Antonio", LastName="Giovinazzi", IDCountry=9, Points=4 }
                    }
                });

            return teams;
        }
    }
}
