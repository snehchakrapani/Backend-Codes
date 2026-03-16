using System;
using System.Collections.Generic;
using System.Text;

namespace Problem.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int Marks { get; set; }
        public double Salary { get; set; }
    }
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public double TotalValue { get; set; }
    }
}