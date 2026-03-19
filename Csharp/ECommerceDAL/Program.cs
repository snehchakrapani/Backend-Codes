using ECommerceDAL.Data;
using ECommerceDAL.Models;
using System.Xml.Linq;
using ECommerceDAL.Queries;

var queries = new ECommerceQueries();

//queries.FetchAllData(); //q1
//queries.FilterSortAggregate(); //q2
queries.GroupByData(); //q3
Console.ReadLine();


//using var db = new AppDbContext();
/*
db.Customers.AddRange(
    new Customer { Name="Sneh", Email= "Snehchakrapani@gmail.com", City="Jaipur"},
    new Customer { Name="Nakul", Email= "Nakulmi@gmail.com", City="Mumbai"},
    new Customer { Name="Hridyansh", Email= "Hridyansh01@gmail.com", City="Indore"},
    new Customer { Name="Saksham", Email= "Sakshamjain@gmail.com", City="Delhi"}
    );
db.Products.AddRange(
   new Product { Name = "Laptop", Category = "Electronics", Price = 75000, Stock = 10 },
    new Product { Name = "Phone", Category = "Electronics", Price = 45000, Stock = 25 },
    new Product { Name = "Shirt", Category = "Clothing", Price = 999, Stock = 50 },
    new Product { Name = "Jeans", Category = "Clothing", Price = 1999, Stock = 30 },
    new Product { Name = "Table", Category = "Furniture", Price = 8000, Stock = 5 }
    );
db.SaveChanges();

db.Orders.AddRange(
    new Order { CustomerID = 1, ProductID = 1, Quantity = 1, TotalValue = 75000, OrderDate = DateTime.Now },
    new Order { CustomerID = 1, ProductID = 2, Quantity = 2, TotalValue = 90000, OrderDate = DateTime.Now },
    new Order { CustomerID = 2, ProductID = 3, Quantity = 3, TotalValue = 2997, OrderDate = DateTime.Now },
    new Order { CustomerID = 3, ProductID = 1, Quantity = 1, TotalValue = 75000, OrderDate = DateTime.Now },
    new Order { CustomerID = 4, ProductID = 4, Quantity = 2, TotalValue = 3998, OrderDate = DateTime.Now }
);

db.SaveChanges(); 
*/
//Console.WriteLine("Data inserted success!");