using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAL.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
