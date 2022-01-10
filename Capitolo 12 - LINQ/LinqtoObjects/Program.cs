

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<F1Team> teams = F1Data.GetTeams();

            //from select
            var carQuery = from car in teams
                           select car;

            SimpleQuery();
            Projection();
            LetClause();
            IntoClause();
            Filtering();
            CompoundFrom();
            Sorting();
            Grouping();
            Join();
            SetOperators();
            Quantifier();
            Partition();
            ElementOperators();
            Conversions();
            Aggregate();
            Generators();

            //altri

            var s1 = Enumerable.Range(1, 10);
            var s2 = Enumerable.Range(11, 10);
            var concat = s1.Concat(s2);

            bool b = s1.SequenceEqual(s2);
            Console.ReadLine();
        }

        private static void Generators()
        {
            Console.WriteLine("----Generation");
            var teams = F1Data.GetTeams();


            var months = Enumerable.Range(1, 12).Select(n => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(n));
            months.ToList().ForEach(Console.WriteLine);

            int[] array = Enumerable.Repeat<int>(1, 10).ToArray();

            var expr = Enumerable.Repeat((from team in teams select team.TeamName), 10);

            IEnumerable<Pilot> pilots = Enumerable.Empty<Pilot>();

            foreach (var pilot in pilots.DefaultIfEmpty(new Pilot() { LastName = "Sconosciuto" }))
            {
                Console.WriteLine(pilot.LastName);
            }
        }

        private static void Aggregate()
        {
            Console.WriteLine("----Elements");
            List<F1Team> teams = F1Data.GetTeams();

            int countTeam = teams.Count(t => t.Wins > 0);

           
            if (teams.TryGetNonEnumeratedCount(out int count))
            {
                Console.Write($"teams contiene {count} elementi");
            }

            var query = from team in teams
                        let points = team.Pilots.Sum(p => p.Points)
                        orderby points descending
                        select new { team.TeamName, points };

            Dump(query);
            int sumPoints = teams.Where(t => t.TeamName.Contains("Ferrari")).SelectMany(t => t.Pilots).Sum(p => p.Points);


            int[] array = { 1, 2, 3, 4, 5 };
            int sum1 = array.Sum();

            var queryAverage = from team in teams
                               select new { team.TeamName, AvgPoints = team.Pilots.Average(p => p.Points) };

            Dump(queryAverage);

            int max = (from team in teams
                       from pilot in team.Pilots
                       select pilot.Points).Max();

            var primo = (from team in teams
                       from pilot in team.Pilots
                       select pilot).MaxBy(p=>p.Points);
            Console.WriteLine($"Al primo posto c'è {primo.LastName} {primo.FirstName} con {primo.Points} punti");

            var ultimo = (from team in teams
                         from pilot in team.Pilots
                         select pilot).MinBy(p => p.Points);
            Console.WriteLine($"All'ultimo posto c'è {ultimo.LastName} {ultimo.FirstName} con {ultimo.Points} punti");

            Console.WriteLine("max={0}", max);

            int min = (from team in teams
                       from pilot in team.Pilots
                       select pilot).Min(p => p.Points);

            Console.WriteLine("max={0}", max);

            string first = (from team in teams
                            select team.TeamName).Min();

            string frase = "ti voglio tanto bene"; //esempio dedicato alla mia amica Francesca
            var acronimo = frase.Split(' ').Aggregate("", (result, word) => result + word.ToUpper().First() + ".");
            Console.WriteLine(acronimo); //stampa TVTB

            var queryAggregate = from team in teams
                                 select new { Points = team.Pilots.Aggregate(0, (total, p) => total + p.Points) };

            Dump(queryAggregate);
        }

        private static void Conversions()
        {
            Console.WriteLine("Elements");
            List<F1Team> teams = F1Data.GetTeams();


            var query1 = teams.Where(t => t.Wins > 0).AsEnumerable();

            List<F1Team> list = teams.Where(t => t.Wins > 0).ToList();
            Pilot[] array = teams.SelectMany(t => t.Pilots).ToArray();

            Dictionary<string, Pilot[]> dict = (from team in teams
                                                where team.Wins > 0
                                                select team).ToDictionary(t => t.TeamName, t => t.Pilots);

            foreach (string key in dict.Keys)
            {
                Console.WriteLine(key);
                foreach (Pilot p in dict[key])
                {
                    Console.WriteLine("- {0}: {1}", p.LastName, p.Points);
                }
            }

            ILookup<F1Team, Pilot[]> lookup = (from team in teams
                                               where team.Wins > 0
                                               select team).ToLookup(t => t, t => t.Pilots);

            Dump(lookup);

            List<object> lista = new List<object>() { "a", 1, "b", 2, "c" };
            var stringhe = lista.OfType<string>();

            int[] intArray = { 1, 2, 3, 4, 5 };
            var objArray = intArray.Cast<object>();

        }

        private static void ElementOperators()
        {
            Console.WriteLine("Elements");
            List<F1Team> teams = F1Data.GetTeams();

            F1Team team = teams.ElementAt(0);

            team = teams.First(t => t.TeamName.Contains("a"));
            team = teams.Last();
            team = teams.SingleOrDefault(t => t.Pilots.Length == 3);
        }

        private static void Partition()
        {
            int[] array = { 1, 1, 2, 3, 1, 2, 1, 3 };

            var query = array.Skip(3);//3, 1,2,1,3
            Console.WriteLine("Skip");
            Dump(query);

            query = array.SkipWhile(i => i == 1);//2,3,2,3
            Console.WriteLine("SkipWhile");
            Dump(query);

            query = array.Take(3);//1,1,2
            Console.WriteLine("Take");
            Dump(query);

            query = array.TakeWhile(i => i < 3);//2,3,2,3
            Console.WriteLine("TakeWhile");
            Dump(query);

            //range
            query = array.Take(..^3);// 1, 1, 2, 3, 1 
            Console.WriteLine("Take (esclusi ultimi 3)");
            Dump(query);

            //range
            query = array.Take(^3..);// 2, 1, 3
            Console.WriteLine("Take (ultimi 3)");
            Dump(query);

            //range
            query = array.Take(3..^2);// 3, 1, 2
            Console.WriteLine("Take (da indice 3 a terzultimo)");
            Dump(query);
        }

        public static void Dump(IEnumerable query)
        {

            foreach (var q in query)
                Console.WriteLine(q);
        }

        public static void SimpleQuery()
        {
            Console.WriteLine("Filtering");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        select team;

            Dump(query);

            ArrayList list = new ArrayList();
            list.AddRange(teams);

            query = from F1Team team in list
                    select team;

            Dump(query);

            //simple projection
            var query1 = from team in teams
                         select team.TeamName;

            Dump(query1);

            //method syntax
            query1 = teams.Select(team => team.TeamName);
            Dump(query1);

        }

        public static void Filtering()
        {
            Console.WriteLine("Filtering");
            List<F1Team> teams = F1Data.GetTeams();
            var query = from team in teams
                        where team.Wins > 0 &&
                            team.TeamName.ToLower().StartsWith("m")
                        select team;

            query.Count();
            Dump(query);

            Console.WriteLine("Where<T>");
            var query2 = teams.Where(team => team.Wins > 0
                && team.TeamName.ToLower().StartsWith("m"));

            Dump(query2);

            Console.WriteLine("Where<T,index>");
            var query3 = teams.Where((team, index) => index % 2 == 0);

            Dump(query3);
        }

        public static void Projection()
        {
            Console.WriteLine("Transform");
            List<F1Team> teams = F1Data.GetTeams();
            var query = from team in teams
                        select team.TeamName.ToUpper();

            Dump(query);

            Console.WriteLine("Transform Select");
            query = teams.Select(team => team.TeamName.ToUpper());
            Dump(query);

            Console.WriteLine("Transform in Tuple");
            var query2 = from team in teams
                         select new Tuple<string, int>(team.TeamName, team.Wins);

            foreach (Tuple<string, int> t in query2)
                Console.WriteLine("{0}: {1}", t.Item1, t.Item2);


            Console.WriteLine("Transform with object initializer");
            var query3 = from team in teams
                         select new F1Team { TeamName = team.TeamName, Wins = team.Wins };
            Dump(query3);

            Console.WriteLine("Transform in anonymous type");
            var query4 = from team in teams
                         select new { team.TeamName, team.Wins };


            foreach (var item in query3)
                Console.WriteLine("{0}: {1}", item.TeamName, item.Wins);

            var query5 = teams.Select(team => new { team.TeamName, team.Wins });

            foreach (var item in query5)
                Console.WriteLine("{0}: {1}", item.TeamName, item.Wins);


            Console.WriteLine("SelectMany");

            var query6 = teams.SelectMany(team => team.Pilots.Where(pilot => pilot.LastName.Length > 7),
                                            (t, pilot) => pilot.LastName);
            Dump(query6);

        }

        public static void CompoundFrom()
        {
            Console.WriteLine("Compound from");


            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        where team.Pilots.Length > 1
                        from pilot in team.Pilots
                        where pilot.LastName.Length > 7
                        select pilot.LastName;
            Dump(query);

            query = from team in teams
                    from pilot in team.Pilots
                    select pilot.LastName;

            Dump(query);

            var query2 = from team in teams
                         from pilot in team.Pilots
                         select new { team.TeamName, pilot.FirstName, pilot.LastName };

            Dump(query);
        }

        public static void Sorting()
        {
            Console.WriteLine("---- sorting");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        orderby team.TeamName
                        select team.TeamName;

            Dump(query);

            Console.WriteLine("---- sorting descending");
            var query2 = from team in teams
                         orderby team.Wins descending, team.TeamName
                         select new { team.Wins, team.TeamName };

            Dump(query2);

            var query3 = teams.OrderBy(team => team.TeamName);
            Dump(query3);

            var query4 = teams.OrderByDescending(team => team.Wins).ThenBy(team => team.TeamName);
            Dump(query4);

            var reverse = (from team in teams
                           where team.Wins > 0
                           select team.TeamName).Reverse();
            Dump(reverse);

        }

        public static void LetClause()
        {
            Console.WriteLine("---- let");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        let wins = team.Wins
                        orderby wins descending
                        where wins > 3
                        select team.TeamName + ": " + wins;

            Dump(query);

            query = from team in teams
                    let wins = team.Wins
                    let pilots = team.Pilots
                    from pilot in pilots
                    where pilot.Points > 80
                    orderby wins descending
                    select team.TeamName + " wins: " + wins + ", leader " + pilot.LastName + " " + pilot.Points;

            Dump(query);

        }

        public static void IntoClause()
        {
            Console.WriteLine("---- Into Clause");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        where team.Wins > 2
                        select team.Pilots
                        into topTeamPilots
                        from tp in topTeamPilots
                        where tp.Points > 50
                        orderby tp.Points descending
                        select tp.LastName + " " + tp.FirstName + ": " + tp.Points;

            Dump(query);
        }

        public static void Grouping()
        {
            Console.WriteLine("---- grouping");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        from pilot in team.Pilots
                        group pilot by team;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key);
                foreach (var pilot in group)
                {
                    Console.WriteLine(" - {0} {1}", pilot.FirstName, pilot.LastName);
                }
            }

            foreach (IGrouping<F1Team, Pilot> group in query)
            {
                F1Team team = group.Key;
                Console.WriteLine(team);
                foreach (Pilot pilot in group)
                {
                    Console.WriteLine(" - {0} {1}", pilot.FirstName, pilot.LastName);
                }
            }


            var query2 = from team in teams
                         from pilot in team.Pilots
                         group pilot by team into t
                         select new { t.Key, t };

            foreach (var pilot in query2)
                Console.WriteLine(pilot.Key);
        }

        public static void Join()
        {
            Console.WriteLine("---- join");
            List<F1Team> teams = F1Data.GetTeams();

            var query = from team in teams
                        from pilot in team.Pilots
                        join country in Country.All on pilot.IDCountry equals country.IDCountry
                        select new { pilot.LastName, CountryName = country.Name };


            foreach (var p in query)
            {
                Console.WriteLine("{0} ({1})", p.LastName, p.CountryName);
            }

            Console.WriteLine("----Join method");
            var query2 = teams.SelectMany(t => t.Pilots).Join(
                Country.All,
                pilot => pilot.IDCountry,
                country => country.IDCountry,
                (p, c) => new { p.LastName, CountryName = c.Name });

            foreach (var p in query2)
            {
                Console.WriteLine("{0} ({1})", p.LastName, p.CountryName);
            }

            Console.WriteLine("----join into");
            var pilots = from team in teams
                         from pilot in team.Pilots
                         select pilot;

            var query3 = from country in Country.All
                         join pilot in pilots on country.IDCountry equals pilot.IDCountry
                         into pilotsxCountry
                         select new { CountryName = country.Name, Pilots = pilotsxCountry };

            foreach (var group in query3)
            {
                Console.WriteLine(group.CountryName);
                foreach (Pilot pilot in group.Pilots)
                {
                    Console.WriteLine("   {0} {1}", pilot.LastName, pilot.FirstName);
                }
            }

            Console.WriteLine("---GroupJoin");
            IEnumerable<Pilot> pilots2 = teams.SelectMany(t => t.Pilots);

            var query4 = Country.All.GroupJoin(
                pilots2,
                country => country.IDCountry,
                pilot => pilot.IDCountry,
                (c, p) => new { CountryName = c.Name, Pilots = p });


            foreach (var group in query4)
            {
                Console.WriteLine(group.CountryName);
                foreach (Pilot pilot in group.Pilots)
                {
                    Console.WriteLine("   {0} {1}", pilot.LastName, pilot.FirstName);
                }
            }
        }

        public static void SetOperators()
        {
            Console.WriteLine("---Set operators");
            int[] array1 = { 1, 2, 3, 4, 5, 3, 4, 5 };
            int[] array2 = { 1, 3, 4, 6, 7, 8 };
            Console.Write("array1: ");
            DumpSet(array1);
            Console.Write("array2: ");
            DumpSet(array2);

            var queryDistinct = array1.Distinct();

            Console.WriteLine("Distinct");
            DumpSet(queryDistinct);


            var union = array1.Union(array2);
            Console.WriteLine("Union");
            DumpSet(union);

            var except = array1.Except(array2);
            Console.WriteLine("Except array1-array2");
            DumpSet(except);

            except = array2.Except(array1);
            Console.WriteLine("Except array2-array1");
            DumpSet(except);

            var intersect = array1.Intersect(array2);
            Console.WriteLine("Intesect");
            DumpSet(intersect);

            var zip = array1.Zip(array2, (a, b) => a + b);
            Console.WriteLine("zip");
            DumpSet(zip);
        }

        public static void Quantifier()
        {
            Console.WriteLine("Quantifiers");
            var teams = F1Data.GetTeams();

            int[] array = { 1, 2, 3, 4 };
            bool contains = array.Contains(1);

            bool allpositive = array.All(i => i > 0);
            var query = teams.Where(t => t.Pilots.All(p => p.Points > 0));
            Console.WriteLine("All");
            Dump(query);

            var queryAny = teams.Where(t => t.Pilots.Any(p => p.Points > 100));
            Console.WriteLine("Any");
            Dump(queryAny);
        }

        private static void DumpSet(IEnumerable query)
        {
            foreach (var i in query)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

        }
    }
}