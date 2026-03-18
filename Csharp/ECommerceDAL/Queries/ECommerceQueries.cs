using System;
using System.Collections.Generic;
using System.Text;
using ECommerceDAL.Data;
using ECommerceDAL.Models;

namespace ECommerceDAL.Queries
{
    public class ECommerceQueries
    {
        readonly AppDbContext db = new AppDbContext();

        public void FetchAllData()

        //query 1
        {
            Console.WriteLine("=== ALL CUSTOMERS ===");

            var customersMS = db.Customers.Select(c => new { c.ID, c.Name, c.Email, c.City }).ToList();
            customersMS.ForEach(c =>
            Console.WriteLine($"ID:{c.ID} | {c.Name} | {c.Email} | {c.City}"));

            Console.WriteLine();

            Console.WriteLine("=== ALL PRODUCTS===");

            var productsMS = db.Products
                  .Select(p => new { p.ID, p.Name, p.Category, p.Price, p.Stock })
                  .ToList();

            productsMS.ForEach(p =>
            Console.WriteLine($"{p.ID} | {p.Name} | {p.Category} | {p.Price} | Stock: {p.Stock}"));
            Console.WriteLine();

            Console.WriteLine("===ALL ORDERS===");

            var ordersMS = db.Orders
                .Select(o => new { o.ID, o.CustomerID, o.ProductID, o.Quantity, o.TotalValue, o.OrderDate })
                .ToList();

            ordersMS.ForEach(o =>
                Console.WriteLine($"ID:{o.ID} | CustID:{o.CustomerID} | ProdID:{o.ProductID} | Qty:{o.Quantity} | Total:{o.TotalValue}"));


        }

        }
}
