using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementSystem.Models
{
    public class SoftwareLicence : Asset
    {
        private string _licenseKey;
        private DateTime _expiryDate;

        public string LicenseKey
        {
            get { return _licenseKey; }
            set { _licenseKey = value; }
        }

        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }

        public SoftwareLicence(int serialnumber, string name, DateTime dateOfAcquisition
            ,string licencekey, DateTime expiryDate) : base(serialnumber, name, dateOfAcquisition)
        {
            _licenseKey = licencekey;   
            _expiryDate = expiryDate;   
        }

        public override string GetAssetType()
        {
            return "Software Licence";
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Licence key: {LicenseKey}");
            Console.WriteLine($"Expiry Date: {ExpiryDate.ToShortTimeString()}");
        }

    }
}
