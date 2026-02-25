using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementSystem.Models
{
    public class Hardware : Asset
    {
        private string _manufacturer;
        private string _warrantyperiod;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }  
        }

        public string WarrantyPeriod
        {
            get { return _warrantyperiod;}
        }

        public Hardware(int serialnumber,string name, DateTime dateOfAcquisition,
            string manufacturer, string warrantyperiod) : base(serialnumber, name, dateOfAcquisition)
        {
            _manufacturer = manufacturer;
            _warrantyperiod = warrantyperiod;
        }

        public override string GetAssetType()
        {
            return "HardWare";
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Manufacture: {Manufacturer}");
            Console.WriteLine($"Warranty Period : {WarrantyPeriod}");
        }

    }
}
