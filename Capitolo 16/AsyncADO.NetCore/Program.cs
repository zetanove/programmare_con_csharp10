using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AsyncADO.NetCore
{
    class Program
    {
        static string connString = "Server=(localdb)\\MSSQLLocalDb;Integrated Security=true;database=SampleDatabase";
        public static async Task Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                Console.WriteLine("connessione aperte: server version=" + connection.ServerVersion);

                SqlCommand cmd = new SqlCommand("SELECT * From Veicolo");
                cmd.Connection = connection;
                var reader = await cmd.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                }
            }
        }
    }
}
