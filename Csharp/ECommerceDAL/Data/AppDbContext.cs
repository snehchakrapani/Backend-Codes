using ECommerceDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ECommerceDAL.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=localhost;" +
                "Database=ECommerceDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;"
            );
        }
    }
}
