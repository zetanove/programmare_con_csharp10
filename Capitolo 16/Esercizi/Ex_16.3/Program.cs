/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 16: 
 * Esercizio 3)
 */


using System;
using System.Data.SqlClient;

namespace Ex_16._3
{
    class Program
    {
        public static string ConnString = "Server=(localdb)\\MSSQLLocalDb;Integrated Security=true;database=FootballDB";


        async static System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Esempio ADO.NET");
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                Console.WriteLine("apro la connessione: " + ConnString);
                connection.Open();

                //utilizza la connessione
                Console.WriteLine("connessione aperta con database: " + connection.Database);

                string sqlInsert = "INSERT INTO Squadre(Nome) VALUES('SquadraTest')";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection);
                int result = await cmdInsert.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    Console.WriteLine("Nuovo record inserito");
                }

                await LeggiSquadre(connection);

                SqlCommand cmdUpdate = new SqlCommand("UPDATE Squadre SET Nome='SquadraModificata' WHERE Nome='SquadraTest'", connection);
                result = await cmdUpdate.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    Console.WriteLine("Squadra modificata");
                }

                await LeggiSquadre(connection);

                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Squadre WHERE Nome='SquadraModificata'", connection);
                result = await cmdDelete.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    Console.WriteLine("Squadra eliminata");
                }

                await LeggiSquadre(connection);

                Console.WriteLine("chiudo la connessione: " + ConnString);
                connection.Close();
            }
        }

        private static async System.Threading.Tasks.Task LeggiSquadre(SqlConnection connection)
        {
            string sql = "SELECT * FROM Squadre";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Console.WriteLine("---- lettura tabella Squadre...");
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"nome squadra: {reader.GetString(1)}");
                }
            }
            Console.WriteLine("---- fine elenco squadre");
        }
    }
}
