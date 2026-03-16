using System;
using System.Collections.Generic;
using System.Linq;
using Problem.Models;

namespace Problem.Problems
{
    internal class Problem5
    {
        public static void Solve()
        {
            Console.WriteLine(" Problem 5: Top 3 Most Expensive Products\n");

            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop",     Price = 75000 },
                new Product { Name = "Phone",      Price = 45000 },
                new Product { Name = "Tablet",     Price = 30000 },
                new Product { Name = "Monitor",    Price = 20000 },
                new Product { Name = "Keyboard",   Price = 3000  }
            };

           
            var result = products
                .OrderByDescending(p => p.Price)
                .Take(3)
                .ToList();

           
            int rank = 1;
            foreach (var p in result)
                Console.WriteLine($"#{rank++} {p.Name} -> Price: {p.Price}");

            Console.WriteLine();
        }
    }
}

