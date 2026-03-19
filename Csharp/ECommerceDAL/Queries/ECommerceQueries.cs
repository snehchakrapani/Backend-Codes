using System;
using System.Collections.Generic;
using System.Linq;
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
        //======================================================================//
        //Query 2 -Use LINQ to filter, sort, and aggregate data in various ways
        //======================================================================//

        public void FilterSortAggregate()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   MOST POPULAR PRODUCTS");
            Console.WriteLine("===============================");

            var popularMS = db.Orders
                .GroupBy(o => o.ProductID)
                .Select(g => new
                {
                    ProductID = g.Key,
                    OrderCount = g.Count()

                })
                .OrderByDescending(x => x.OrderCount)
                .ToList();

            popularMS.ForEach(p =>
        Console.WriteLine($"ProductID:{p.ProductID} | Orders:{p.OrderCount}"));



            Console.WriteLine("\n==============================");
            Console.WriteLine("   TOP CUSTOMERS");
            Console.WriteLine("================================");

            var topCustomers = db.Orders
     .GroupBy(o => o.CustomerID)
     .OrderByDescending(g => g.Count())
     .Select(g => new
     {
         CustomerID = g.Key,
         OrderCount = g.Count()
     })
     .ToList();

            topCustomers.ForEach(c =>
                Console.WriteLine($"CustomerID:{c.CustomerID} | Orders:{c.OrderCount}"));

            Console.WriteLine("\n==============================");
            Console.WriteLine("   TOTAL SALES");
            Console.WriteLine("================================");

            var totalSales = db.Orders.Sum(o => o.TotalValue);
            var highValueOrders = db.Orders
                .Where(o => o.TotalValue > 50000)
                .OrderByDescending(o => o.TotalValue)
                .ToList();

            Console.WriteLine($"Total Revenue: {totalSales}");
            Console.WriteLine($"High Value Orders (>50000): {highValueOrders.Count}");
            highValueOrders.ForEach(o =>
                Console.WriteLine("OrderID:" + o.ID + " | Total:" + o.TotalValue));
        }

        public void GroupByData()
        {

            Console.WriteLine("\n==============================");
            Console.WriteLine("   CUSTOMERS BY CITY");
            Console.WriteLine("================================");


            var byCityMS = db.Customers
                .GroupBy(c => c.City)
                .Select(g => new
                {
                    City = g.Key,
                    Count = g.Count(),
                    Names = g.Select(c => c.Name).ToList()
                })
                .ToList();

            byCityMS.ForEach(g =>
            {
                Console.WriteLine($"City: {g.City} | Count: {g.Count}");
                g.Names.ForEach(n => Console.WriteLine($" {n}"));
            });

            Console.WriteLine("\n==============================");
            Console.WriteLine("   PRODUCTS BY CATEGORY");
            Console.WriteLine("================================");


            var byCategoryMS = db.Products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    AvgPrice = g.Average(p => p.Price),
                    TotalStock = g.Sum(p => p.Stock)
                })
                .ToList();
            byCategoryMS.ForEach(g =>
                Console.WriteLine($"Category: {g.Category} | Count: {g.Count} | AvgPrice: {g.AvgPrice} | Stock: {g.TotalStock}"));

        }

        public void JoinData() //q-4
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   CUSTOMER + ORDER + PRODUCT");
            Console.WriteLine("==============================");


            var MS = db.Orders
                .Join(db.Customers,
                      o => o.CustomerID,
                      c => c.ID,
                      (o, c) => new { o, c })
                .Join(db.Products,
                      x => x.o.ProductID,
                      p => p.ID,
                      (x, p) => new
                      {
                          Customer = x.c.Name,
                          Product = p.Name,
                          Category = p.Category,
                          Qty = x.o.Quantity,
                          Total = x.o.TotalValue
                      })
                .ToList();
            MS.ForEach(r =>
                Console.WriteLine($"{r.Customer} | {r.Product} | {r.Category} | Qty:{r.Qty} | {r.Total}"));
        }


        public void ChainedQueries() //q5
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   HIGH VALUE ELECTRONICS");
            Console.WriteLine("================================");


            var MS = db.Orders
                .Join(db.Customers,
                      o => o.CustomerID,
                      c => c.ID,
                      (o, c) => new { o, c })
                .Join(db.Products,
                      x => x.o.ProductID,
                      p => p.ID,
                      (x, p) => new { x.o, x.c, p })
                .Where(x => x.p.Category == "Electronics")
                .Where(x => x.o.TotalValue > 50000)
                .OrderByDescending(x => x.o.TotalValue)
                .Select(x => new
                {
                    Customer = x.c.Name,
                    Product = x.p.Name,
                    Total = x.o.TotalValue
                })
                .ToList();
            MS.ForEach(r =>
                Console.WriteLine($"{r.Customer} | {r.Product} | {r.Total}"));
        }
        }
    }