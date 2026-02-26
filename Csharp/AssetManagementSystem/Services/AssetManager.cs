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
    }
}