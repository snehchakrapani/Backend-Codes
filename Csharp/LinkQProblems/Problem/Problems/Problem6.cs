using Problem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Problem.Problems
{
    internal class Problem6
    {
        public static void Solve()
        {
            Console.WriteLine("Problem 6: Join Customers & Orders \n");

            List<Customer> customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Alice"   },
                new Customer { ID = 2, Name = "Bob"     },
                new Customer { ID = 3, Name = "Charlie" }
            };

            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 101, CustomerID = 1, TotalValue = 250 },
                new Order { OrderID = 102, CustomerID = 1, TotalValue = 480 },
                new Order { OrderID = 103, CustomerID = 2, TotalValue = 900 },
                new Order { OrderID = 104, CustomerID = 3, TotalValue = 150 }
            };

            
            var result = customers
                .Join(orders,
                      c => c.ID,
                      o => o.CustomerID,
                      (c, o) => new
                      {
                          CustomerName = c.Name,
                          o.OrderID,
                          o.TotalValue
                      })
                .ToList();

            
            foreach (var item in result)
                Console.WriteLine($"Name: {item.CustomerName} | OrderID: {item.OrderID} | Total: {item.TotalValue}");

            Console.WriteLine();
        }
    }
}

