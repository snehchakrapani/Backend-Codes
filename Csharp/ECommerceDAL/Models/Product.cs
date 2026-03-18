using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAL.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
