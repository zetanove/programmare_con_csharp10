using System;
using System.Data;
using System.Data.SqlClient;

namespace DisconnectedADO_NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=(localDB)\\MSSQLLocalDB;Integrated Security=true;database=WideWorldImporters";

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Sales.Orders", conn);
                adapter.Fill(ds, "Products");
            }

            DataTable dt = ds.Tables[0];
            Console.WriteLine("{0} record", dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(string.Format("ID: {0} , Date: {1}",
                row["OrderID"], row["OrderDate"]));
            }


        }
    }
}
