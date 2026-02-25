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
            get { return _licenseKey; } set { _licenseKey = value; 
        }



    }
}
