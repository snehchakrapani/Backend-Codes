using System;
using System.Collections.Generic;
using AssetManagementSystem.Models;


namespace AssetManagementSystem.Services
{
    // This class manages all asset operations
    
    public class AssetManager
    {
       
        private List<Asset> _assets;

        
        private int _nextSerialNumber;

        // Constructor - initializes the AssetManager
        
        public AssetManager()
        {
            // Create new empty list
            _assets = new List<Asset>();

         
            _nextSerialNumber = 1;
        }

        // Method to get next available serial number
      
        private int GetNextSerialNumber()
        {
            
            return _nextSerialNumber++;
        }

        // USE CASE 1: LIST ALL ASSETS
        
        public void ListAllAssets()
        {
            
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("           LIST OF ALL ASSETS");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            if (_assets.Count == 0)
            {
              
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo assets found in the system.");
                Console.WriteLine("Please add assets using 'Add Asset' option.");
                Console.ResetColor();
            }
            else
            {
              
                foreach (Asset asset in _assets)
                {
                    Console.WriteLine(); // Blank line for spacing

                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Asset Type: {asset.GetAssetType()}");
                    Console.ResetColor();

                    // DisplayDetails - polymorphism
                  
                    asset.DisplayDetails();

                  
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(new string('-', 50));
                    Console.ResetColor();
                }

                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nTotal Assets: {_assets.Count}");
                Console.ResetColor();
            }

            
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        // USE CASE 2: ADD ASSET

        public void AddAsset()
        {
            Console.Clear();

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("              ADD NEW ASSET");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

          
            Console.WriteLine("\nSelect Asset Type:");
            Console.WriteLine("  1. Book");
            Console.WriteLine("  2. Software License");
            Console.WriteLine("  3. Hardware");
            Console.Write("\nEnter your choice (1-3): ");

            
            string choice = Console.ReadLine();

            Asset newAsset = null;

     
            switch (choice)
            {
                case "1":
                  
                    newAsset = AddBook();
                    break;

                case "2":
                    
                    newAsset = AddSoftware();
                    break;

                case "3":
                    
                    newAsset = AddHardware();
                    break;

                default:
                    
                     Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice! Please select 1, 2, or 3.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    return; 
            }

            
            if (newAsset != null)
            {
                
                _assets.Add(newAsset);

                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ Asset added successfully!");
                Console.ResetColor();

                
                Console.WriteLine("\nAsset Details:");
               
                Console.WriteLine($"Asset Type: {newAsset.GetAssetType()}");
         
                newAsset.DisplayDetails();
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        public void SearchAsset()
        {
            Console.Clear();
            Console.WriteLine("\n--------Search Asset--------");

            if (_assets.Count == 0)
            {
                Console.WriteLine("No assets available to search.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Select Asset Type to search:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Software License");
            Console.WriteLine("3. Hardware");
            Console.Write("\nEnter your choice (1-3): ");

            string typeChoice = Console.ReadLine();
            string assetType = "";

            switch (typeChoice)
            {
                case "1":
                    assetType = "Book";
                    break;
                case "2":
                    assetType = "Software License";
                    break;
                case "3":
                    assetType = "Hardware";
                    break;
                default:
                    Console.WriteLine("\nInvalid choice.");
                    Console.ReadKey();
                    return;
            }

            Console.Write("\nEnter search term (Name or Serial Number): ");
            string searchTerm = Console.ReadLine().ToLower();

            List<Asset> foundAssets = new List<Asset>();

            foreach (Asset asset in _assets)
            {
                if (asset.GetAssetType() == assetType)
                {
                    bool matchesName = asset.Name.ToLower().Contains(searchTerm);
                    bool matchesSerial = asset.SerialNumber.ToString() == searchTerm;

                    if (matchesName || matchesSerial)
                    {
                        foundAssets.Add(asset);
                    }
                }
            }

            if (foundAssets.Count == 0)
            {
                Console.WriteLine("\nNo matching assets found.");
            }
            else
            {
                Console.WriteLine($"\n{foundAssets.Count} assets found:\n");

                foreach (Asset asset in foundAssets)
                {
                    Console.WriteLine($"Asset Type: {asset.GetAssetType()}");
                    Console.WriteLine(new string('-', 40));
                    asset.DisplayDetails();
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


        public void UpdateAsset()
        {
            Console.Clear();
            Console.WriteLine("\n--- Update Asset ---\n");

            if (_assets.Count == 0)
            {
                Console.WriteLine("No assets available to update.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Select Asset Type to update:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Software License");
            Console.WriteLine("3. Hardware");
            Console.Write("\nEnter your choice (1-3): ");

            string typeChoice = Console.ReadLine();
            string assetType = "";

            switch (typeChoice)
            {
                case "1":
                    assetType = "Book";
                    break;
                case "2":
                    assetType = "Software License";
                    break;
                case "3":
                    assetType = "Hardware";
                    break;
                default:
                    Console.WriteLine("\nInvalid choice.");
                    Console.ReadKey();
                    return;
            }

            Console.Write("\nEnter Serial Number of asset to update: ");
            string serialInput = Console.ReadLine();

            if (!int.TryParse(serialInput, out int serialNumber))
            {
                Console.WriteLine("\nInvalid serial number.");
                Console.ReadKey();
                return;
            }

            Asset asset = _assets.FirstOrDefault(a =>
                a.SerialNumber == serialNumber &&
                a.GetAssetType() == assetType
            );

            if (asset == null)
            {
                Console.WriteLine("\nAsset not found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nCurrent Asset Details:");
            Console.WriteLine(new string('-', 40));
            asset.DisplayDetails();
            Console.WriteLine(new string('-', 40));

            if (asset is Book book)
            {
                UpdateBook(book);
            }
            else if (asset is SoftwareLicence software)
            {
                UpdateSoftware(software);
            }
            else if (asset is Hardware hardware)
            {
                UpdateHardware(hardware);
            }
        }


        public void DeleteAsset()
        {
            Console.Clear();
            Console.WriteLine("\n--- Delete Asset ---\n");

            if (_assets.Count == 0)
            {
                Console.WriteLine("No assets available to delete.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Select Asset Type to delete:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Software License");
            Console.WriteLine("3. Hardware");
            Console.Write("\nEnter your choice (1-3): ");

            string typeChoice = Console.ReadLine();
            string assetType = "";

            switch (typeChoice)
            {
                case "1":
                    assetType = "Book";
                    break;
                case "2":
                    assetType = "Software License";
                    break;
                case "3":
                    assetType = "Hardware";
                    break;
                default:
                    Console.WriteLine("\nInvalid choice.");
                    Console.ReadKey();
                    return;
            }

            Console.Write("\nEnter Serial Number of asset to delete: ");
            string serialInput = Console.ReadLine();

            if (!int.TryParse(serialInput, out int serialNumber))
            {
                Console.WriteLine("\nInvalid serial number.");
                Console.ReadKey();
                return;
            }

            Asset foundAsset = null;

            foreach (Asset asset in _assets)
            {
                if (asset.SerialNumber == serialNumber && asset.GetAssetType() == assetType)
                {
                    foundAsset = asset;
                    break;
                }
            }

            if (foundAsset == null)
            {
                Console.WriteLine("\nAsset not found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAsset to be deleted:");
            Console.WriteLine(new string('-', 40));
            foundAsset.DisplayDetails();
            Console.WriteLine(new string('-', 40));

            Console.Write("\nAre you sure you want to delete this asset? (yes/no): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "yes")
            {
                _assets.Remove(foundAsset);
                Console.WriteLine("\nAsset deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nDeletion cancelled.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // HELPER METHOD: ADD BOOK

        private Book AddBook()
        {
            Console.WriteLine("\n Adding Book");

            
            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

           
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Book name cannot be empty");
                Console.ResetColor();
                return null; // Return null to indicate failure
            }

            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(author))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Author name cannot be empty");
                Console.ResetColor();
                return null;
            }

            Console.Write("Enter Date of Publish (MM-DD-YYYY): ");
            string publishDateStr = Console.ReadLine();

            DateTime publishDate;
            // Try to parse date - handle invalid input
            if (!DateTime.TryParse(publishDateStr, out publishDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid date format!");
                Console.ResetColor();
                return null;
            }

           
            // Get auto-incremented serial number
            // Date of acquisition is today
            Book book = new Book(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                author: author,
                dateofpublish: publishDate
            );

            return book; // Return the created book
        }

   
        private SoftwareLicence AddSoftware()
        {
            Console.WriteLine("\n Adding Software License ");

            Console.Write("Enter Software Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Software name cannot be empty!");
                Console.ResetColor();
                return null;
            }

            Console.Write("Enter License Key: ");
            string licenseKey = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(licenseKey))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: License key cannot be empty!");
                Console.ResetColor();
                return null;
            }

            Console.Write("Enter Expiry Date (MM-DD-YYYY): ");
            string expiryDateStr = Console.ReadLine();

            DateTime expiryDate;
            if (!DateTime.TryParse(expiryDateStr, out expiryDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid date format!");
                Console.ResetColor();
                return null;
            }

            // Create SoftwareLicense object
            SoftwareLicence software = new SoftwareLicence(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                licencekey: licenseKey,
                expiryDate: expiryDate
            );

            return software;
        }

        private Hardware AddHardware()
        {
            Console.WriteLine("\n Adding Hardware ");

            Console.Write("Enter Hardware Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) //empty or just spaces
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Hardware name cannot be empty!");
                Console.ResetColor();
                return null;
            }

            Console.Write("Enter Manufacturer: ");
            string manufacturer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Manufacturer cannot be empty!");
                Console.ResetColor();
                return null;
            }

            Console.Write("Enter Warranty Period (e.g '2 years'): ");
            string warrantyPeriod = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(warrantyPeriod))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Warranty period cannot be empty!");
                Console.ResetColor();
                return null;
            }

            // Create Hardware object
            Hardware hardware = new Hardware(
                serialnumber: GetNextSerialNumber(),
                name: name,
                dateOfAcquisition: DateTime.Now,
                manufacturer: manufacturer,
                warrantyperiod: warrantyPeriod
            );

            return hardware;
        }

        private void UpdateBook(Book book)
        {
            Console.WriteLine("\nWhat would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. Date of Publish");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new Name: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        book.Name = newName;
                        Console.WriteLine("\nName updated successfully!");
                    }
                    break;

                case "2":
                    Console.Write("Enter new Author: ");
                    string newAuthor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAuthor))
                    {
                        book.Author = newAuthor;
                        Console.WriteLine("\nAuthor updated successfully!");
                    }
                    break;

                case "3":
                    Console.Write("Enter new Date of Publish (MM-DD-YYYY): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                    {
                        book.DateOfPublish = newDate;
                        Console.WriteLine("\nDate of Publish updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid date format.");
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void UpdateSoftware(SoftwareLicence software)
        {
            Console.WriteLine("\nWhat would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. License Key");
            Console.WriteLine("3. Expiry Date");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new Name: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        software.Name = newName;
                        Console.WriteLine("\nName updated successfully!");
                    }
                    break;

                case "2":
                    Console.Write("Enter new License Key: ");
                    string newKey = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newKey))
                    {
                        software.LicenseKey = newKey;
                        Console.WriteLine("\nLicense Key updated successfully!");
                    }
                    break;

                case "3":
                    Console.Write("Enter new Expiry Date (MM-DD-YYYY): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                    {
                        software.ExpiryDate = newDate;
                        Console.WriteLine("\nExpiry Date updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid date format.");
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateHardware(Hardware hardware)
        {
            Console.WriteLine("\nWhat would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Manufacturer");
            Console.WriteLine("3. Warranty Period");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new Name: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        hardware.Name = newName;
                        Console.WriteLine("\nName updated successfully!");
                    }
                    break;

                case "2":
                    Console.Write("Enter new Manufacturer: ");
                    string newManufacturer = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newManufacturer))
                    {
                        hardware.Manufacturer = newManufacturer;
                        Console.WriteLine("\nManufacturer updated successfully!");
                    }
                    break;

                case "3":
                    Console.Write("Enter new Warranty Period: ");
                    string newWarranty = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newWarranty))
                    {
                        hardware.WarrantyPeriod = newWarranty;
                        Console.WriteLine("\nWarranty Period updated successfully!");
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}