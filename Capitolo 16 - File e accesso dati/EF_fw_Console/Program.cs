using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_fw_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WideWorldImportersEntities db = new WideWorldImportersEntities())
            {
                var query = from order in db.Orders
                            select order;

                foreach (Orders o in query.Take(100))
                {
                    Console.WriteLine($"{o.OrderID}, n° {o.CustomerPurchaseOrderNumber} del {o.OrderDate}");
                }

                var query2 = from line in db.OrderLines
                             join order in db.Orders on line.OrderID equals order.OrderID
                             where line.Description.ToLower().Contains("joke")
                             select order;
                foreach (var o in query2.Take(100))
                {
                    Console.WriteLine($"order n° {o.CustomerPurchaseOrderNumber}, quantità {o.Invoices.Sum(inv => inv.InvoiceLines.Sum(l => l.Quantity))}");
                }

                Customers customer = new Customers();
                customer.CustomerName = "Antonio Pelleriti";
                customer.PhoneNumber = "39123";
                db.Customers.Add(customer);
                //db.aveChanges();


                var lines = db.Database.SqlQuery<string>("select Description from Sales.OrderLines where Description LIKE '%joke%'");
                List<string> desc = lines.ToList();

            }
        }
    }
}
