using System;
using AssetManagementSystem.Services;

namespace AssetManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create AssetManager instance
            AssetManager manager = new AssetManager();

            bool testing = true;

            while (testing)
            {
                Console.Clear();
                Console.WriteLine("=== TESTING ASSET MANAGER ===");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. List All Assets");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.AddAsset();
                        break;
                    case "2":
                        manager.ListAllAssets();
                        break;
                    case "3":
                        testing = false;
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}



/*
           Console.WriteLine("Testing Asset Classes");
           //test 1
           Book book = new Book(
               serialnumber:1,
               name: "Creating Abundance",
               dateOfAcquisition: new DateTime(2026,2,25),
               author:"Jeet kumar",
               dateofpublish: new DateTime(2026,1,1)
               );

           Console.WriteLine($"Asset Type: {book.GetAssetType()}");
           book.DisplayDetails();
           Console.WriteLine("\n" + new string('-', 40) + "\n");



           SoftwareLicence software = new SoftwareLicence(
               serialnumber: 2,
               name: "MIcrosoft Office",
               dateOfAcquisition: new DateTime(2026,2,22),
               licencekey: "2XXX-XXXXX-XX5XX-XXX1XX",
               expiryDate: new DateTime(2026,1,20)
               );


           Console.WriteLine($"Asset Type: {software.GetAssetType()}");
           software.DisplayDetails();
           Console.WriteLine("\n" + new string('-', 40) + "\n");

           Hardware hardware = new Hardware(
               serialnumber: 3,
               name: "Hp Laptop",
               dateOfAcquisition: new DateTime(2026,1,1),
               manufacturer: "HP",
               warrantyperiod: "3 Years"
               );

           Console.WriteLine($"Asset Type: {hardware.GetAssetType()}");
           hardware.DisplayDetails();

           Console.WriteLine("\n\nPress any key to exit...");
           Console.ReadKey();
           */