using AssetManagementSystem.Models;

namespace AssetManagementSystem.Services
{
    public class AssetManager
    {
        private List<Asset> _assets;
        private int _nextSerialNumber;

        public AssetManager()
        {
            _assets = new List<Asset>();
            _nextSerialNumber = 1;
        }

        private int GetNextSerialNumber()
        {
            return _nextSerialNumber++;
        }

     
        public object GetAllAssets()
        {
            if (_assets.Count == 0)
                return new { message = "No assets found" };

            var books = _assets.OfType<Book>()
                .Select(b => new {
                    b.SerialNumber,
                    b.Name,
                    b.Author,
                    b.DateOfPublish,
                    b.AssignedTo,
                    Type = "Book"
                });

            var software = _assets.OfType<SoftwareLicence>()
                .Select(s => new {
                    s.SerialNumber,
                    s.Name,
                    s.LicenseKey,
                    s.ExpiryDate,
                    s.AssignedTo,
                    Type = "Software License"
                });

            var hardware = _assets.OfType<Hardware>()
                .Select(h => new {
                    h.SerialNumber,
                    h.Name,
                    h.Manufacturer,
                    h.WarrantyPeriod,
                    h.AssignedTo,
                    Type = "Hardware"
                });

            return new
            {
                AssetList = new
                {
                    Books = books,
                    Software = software,
                    Hardware = hardware
                },
                TotalAssets = _assets.Count
            };
        }
      

        public (bool success, string message, Asset? asset) AddBook(
            string name, string author, DateTime dateOfPublish)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Book name cannot be empty", null);

            if (string.IsNullOrWhiteSpace(author))
                return (false, "Author cannot be empty", null);

            var book = new Book(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                author: author,
                dateofpublish: dateOfPublish
            );

            _assets.Add(book);
            return (true, "Book added successfully!", book);
        }

      
        public (bool success, string message, Asset? asset) AddSoftware(
            string name, string licenseKey, DateTime expiryDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Software name cannot be empty", null);

            if (string.IsNullOrWhiteSpace(licenseKey))
                return (false, "License key cannot be empty", null);

            var software = new SoftwareLicence(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                licencekey: licenseKey,
                expiryDate: expiryDate
            );

            _assets.Add(software);
            return (true, "Software License added successfully!", software);
        }

        public (bool success, string message, Asset? asset) AddHardware(
            string name, string manufacturer, string warrantyPeriod)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (false, "Hardware name cannot be empty", null);

            if (string.IsNullOrWhiteSpace(manufacturer))
                return (false, "Manufacturer cannot be empty", null);

            var hardware = new Hardware(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                manufacturer: manufacturer,
                warrantyperiod: warrantyPeriod
            );

            _assets.Add(hardware);
            return (true, "Hardware added successfully!", hardware);
        }

       
        public (bool success, string message, List<object> results) SearchAsset(
            string assetType, string searchTerm)
        {
            var results = new List<object>();

            foreach (var asset in _assets)
            {
                if (asset.GetAssetType() != assetType) continue;

                bool matchesName = asset.Name.ToLower()
                                     .Contains(searchTerm.ToLower());
                bool matchesSerial = asset.SerialNumber.ToString()
                                     == searchTerm;

                if (matchesName || matchesSerial)
                    results.Add(asset);
            }

            if (results.Count == 0)
                return (false, "No matching assets found", results);

            return (true, $"{results.Count} asset(s) found", results);
        }

        public (bool success, string message) UpdateAsset(
            int serialNumber, string assetType,
            string? name, string? extraField1, string? extraField2)
        {
            var asset = FindAsset(serialNumber, assetType);

            if (asset == null)
                return (false, "Asset not found");

            if (!string.IsNullOrWhiteSpace(name))
                asset.Name = name;

            if (asset is Book book)
            {
                if (!string.IsNullOrWhiteSpace(extraField1))
                    book.Author = extraField1;
                if (!string.IsNullOrWhiteSpace(extraField2) &&
                    DateTime.TryParse(extraField2, out DateTime date))
                    book.DateOfPublish = date;
            }
            else if (asset is SoftwareLicence sw)
            {
                if (!string.IsNullOrWhiteSpace(extraField1))
                    sw.LicenseKey = extraField1;
                if (!string.IsNullOrWhiteSpace(extraField2) &&
                    DateTime.TryParse(extraField2, out DateTime date))
                    sw.ExpiryDate = date;
            }
            else if (asset is Hardware hw)
            {
                if (!string.IsNullOrWhiteSpace(extraField1))
                    hw.Manufacturer = extraField1;
                if (!string.IsNullOrWhiteSpace(extraField2))
                    hw.WarrantyPeriod = extraField2;
            }

            return (true, "Asset updated successfully!");
        }

        public (bool success, string message, int updatedCount) UpdateAssetsByType(
            string assetType,
            string? name,
            string? extraField1,
            string? extraField2)
        {
            var assetsToUpdate = _assets
                .Where(a => string.Equals(a.GetAssetType(), assetType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (assetsToUpdate.Count == 0)
                return (false, "No assets found for the given type", 0);

            DateTime parsedDate = default;
            bool hasParsedDate = !string.IsNullOrWhiteSpace(extraField2) &&
                                 DateTime.TryParse(extraField2, out parsedDate);

            foreach (var asset in assetsToUpdate)
            {
                if (!string.IsNullOrWhiteSpace(name))
                    asset.Name = name;

                if (asset is Book book)
                {
                    if (!string.IsNullOrWhiteSpace(extraField1))
                        book.Author = extraField1;
                    if (hasParsedDate)
                        book.DateOfPublish = parsedDate;
                }
                else if (asset is SoftwareLicence sw)
                {
                    if (!string.IsNullOrWhiteSpace(extraField1))
                        sw.LicenseKey = extraField1;
                    if (hasParsedDate)
                        sw.ExpiryDate = parsedDate;
                }
                else if (asset is Hardware hw)
                {
                    if (!string.IsNullOrWhiteSpace(extraField1))
                        hw.Manufacturer = extraField1;
                    if (!string.IsNullOrWhiteSpace(extraField2))
                        hw.WarrantyPeriod = extraField2;
                }
            }

            return (true, $"{assetsToUpdate.Count} asset(s) updated successfully!", assetsToUpdate.Count);
        }

     
        public (bool success, string message) DeleteAsset(
            int serialNumber, string assetType)
        {
            var asset = FindAsset(serialNumber, assetType);

            if (asset == null)
                return (false, "Asset not found");

            _assets.Remove(asset);
            return (true, $"{assetType} with Serial Number {serialNumber} deleted successfully!");
        }

        public (bool success, string message) RequestAsset(
  int serialNumber, string assetType, string requestedBy)
        {
            var asset = FindAsset(serialNumber, assetType);

            if (asset == null)
                return (false, "Asset not found");

            
            string status = string.IsNullOrWhiteSpace(asset.AssignedTo)
                ? "available"
                : $"currently assigned to {asset.AssignedTo}";

            return (true,
                $"Request for {assetType} '{asset.Name}' " +
                $"(Serial: {serialNumber}) by {requestedBy} " +
                $"submitted. Asset is {status}.");
        }

        public (bool success, string message) AssignAsset(
            int serialNumber, string assetType, string userName)
        {
            var asset = FindAsset(serialNumber, assetType);

            if (asset == null)
                return (false, "Asset not found");

            asset.AssignedTo = userName;
            return (true, $"Asset assigned to {userName} successfully!");
        }

        public (bool success, string message) UnassignAsset(
            int serialNumber, string assetType)
        {
            var asset = FindAsset(serialNumber, assetType);

            if (asset == null)
                return (false, "Asset not found");

            if (string.IsNullOrWhiteSpace(asset.AssignedTo))
                return (false, "Asset is not assigned to anyone");

            asset.AssignedTo = null;
            return (true, "Asset unassigned successfully!");
        }

        
        private Asset? FindAsset(int serialNumber, string assetType)
        {
            foreach (var asset in _assets)
            {
                if (asset.SerialNumber == serialNumber &&
                    asset.GetAssetType() == assetType)
                    return asset;
            }
            return null;
        }
    }
}