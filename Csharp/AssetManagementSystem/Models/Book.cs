using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementSystem.Models
{
    public class Book : Asset
    {
        private string _author;
        private DateTime _dateofpublish;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public DateTime DateOfPublish
        {
            get { return _dateofpublish;  }
            set { _dateofpublish = value; } 
        }

        // will call parent constructor using base 
        public Book(int serialnumber,string name ,DateTime dateOfAcquisition ,string author, DateTime dateofpublish)
            : base(serialnumber, name, dateOfAcquisition)
        {
           _author = author;    
            _dateofpublish = dateofpublish; 
        }

        public override string GetAssetType()
        {
            return "Book";  //ovveriding abstract method
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails(); 
            Console.WriteLine($"Author:           {Author}");
            Console.WriteLine($"Date of Publish:  {DateOfPublish.ToShortDateString()}");
        }
    }
}