using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementSystem.Models
{
    //abstract so that we cannot create objects of class directly - It's meant to be inherited by other classes
    public abstract class Asset
    {
        private int _serialnumber;
        private string _name;
        private DateTime _dateOfAcquisition;

        //made property for control access of private fields
        public int SerialNumber
        {
            get { return _serialnumber; }
            set { _serialnumber = value; }
        }

        public string Name
        {
            get { return _name; }    
            set {  _name = value; }
        }

        public DateTime DateOfAcquisition
        {
            get { return _dateOfAcquisition; }
            set { _dateOfAcquisition = value; }
        }
        // Constructor runs when i create  a new asset
        public Asset(int serialnumber, string name, DateTime dateOfAcquisition)
        {
            _serialnumber = serialnumber;
            _name = name;   
            _dateOfAcquisition = dateOfAcquisition;
        }

        //virtual method - can be overridden by child classes(pm)

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Serial number: {SerialNumber}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Date of Acquisition: {DateOfAcquisition}");
        }

        // Used to get the type name for display
        public abstract string GetAssetType();
    }
}