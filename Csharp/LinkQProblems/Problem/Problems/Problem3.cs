using System;
using System.Collections.Generic;
using System.Linq;
using Problem.Models;

namespace Problem.Problems
{
    public class Problem3
    {
        public static void Run()
        {
            Console.WriteLine("\n=== PROBLEM 3: Group by Category + Total Quantity ===");

            List<Product> products = new List<Product>()
            {
                new Product { Name="Laptop",  Category="Electronics", quantity=5  },
                new Product { Name="Phone",   Category="Electronics", quantity=10 },
                new Product { Name="Tablet",  Category="Electronics", quantity=8  },
                new Product { Name="Shirt",   Category="Clothing",    quantity=20 },
                new Product { Name="Pants",   Category="Clothing",    quantity=15 },
                   new Product { Name="Pizza",   Category="Food",     quantity=50 },
                new Product { Name="ColdCoffee",  Category="Food",    quantity=30 }
            };

            var result = products
                         .GroupBy(p => p.Category)
                         .Select(g => new
                         {
                             Category = g.Key,
                             TotalQuantity = g.Sum(p => p.quantity)
                         });

            foreach (var item in result)
                Console.WriteLine($"  {item.Category} : Total Qty: {item.TotalQuantity}");
        }
    }
}