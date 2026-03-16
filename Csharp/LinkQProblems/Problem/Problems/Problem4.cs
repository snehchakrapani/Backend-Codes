using System;
using System.Collections.Generic;
using System.Linq;
using Problem.Models;

namespace Problem.Problems
{
    internal class Problem4
    {
        public static void Solve()
        {
            Console.WriteLine("Problem 4: Customers with Order Total > Threshold \n");

            List<Customer> customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Alice" },
                new Customer { ID = 2, Name = "Bob"   },
                new Customer { ID = 3, Name = "Charlie" }
            };

            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 101, CustomerID = 1, TotalValue = 300 },
                new Order { OrderID = 102, CustomerID = 2, TotalValue = 800 },
                new Order { OrderID = 103, CustomerID = 3, TotalValue = 150 }
            };

            double threshold = 500;

           
            var result = customers
                .Join(orders,
                      c => c.ID,
                      o => o.CustomerID,
                      (c, o) => new { c.Name, o.OrderID, o.TotalValue })
                .Where(x => x.TotalValue > threshold)
                .ToList();

            
            foreach (var item in result)
                Console.WriteLine($"Name: {item.Name} | OrderID: {item.OrderID} | Total: {item.TotalValue}");

            Console.WriteLine();
        }
    }
}