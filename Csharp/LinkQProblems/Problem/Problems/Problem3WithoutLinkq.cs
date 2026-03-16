using System;
using System.Collections.Generic;
using System.Text;
using Problem.Models;

namespace Problem.Problems
{
    internal class Problem3WithoutLinkq
    {
        public static void Solve()
        {
            Console.WriteLine(" Problem 3 Without LINQ: Group Products by Category \n");

            List<Product> products = new List<Product>
            {
                new Product { Name = "Apple",   Category = "Fruits",  quantity = 10 },
                new Product { Name = "Banana",  Category = "Fruits",  quantity = 5  },
                new Product { Name = "Mango",   Category = "Fruits",  quantity = 3  },
                new Product { Name = "Carrot",  Category = "Veggies", quantity = 8  },
                new Product { Name = "Spinach", Category = "Veggies", quantity = 6  },
                new Product { Name = "Milk",    Category = "Dairy",   quantity = 12 }
            };

        
            Dictionary<string, int> categoryTotals = new Dictionary<string, int>();

            
            foreach (Product p in products)
            {
               
                if (categoryTotals.ContainsKey(p.Category))
                {
                    categoryTotals[p.Category] += p.quantity;
                }
                else
                {
                   
                    categoryTotals[p.Category] = p.quantity;
                }
            }

            Console.WriteLine("Category wise Total Quantity:");
         
            foreach (var entry in categoryTotals)
            {
                Console.WriteLine($"{entry.Key} = Total Qty: {entry.Value}");
            }

            Console.WriteLine();
        }
    }
}