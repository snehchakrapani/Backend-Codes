using AssetManagementSystem.Services;

namespace AssetManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register AssetManager as Singleton
            
            builder.Services.AddSingleton<AssetManager>();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}



/*
using System;
using AssetManagementSystem.Services;

namespace AssetManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AssetManager manager = new AssetManager();
            bool running = true;

            Console.WriteLine("\nAsset Management System");
            Console.WriteLine("========================\n");

            while (running)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Add an asset");
                Console.WriteLine("2. Search an asset");
                Console.WriteLine("3. Update an asset");
                Console.WriteLine("4. Delete an asset");
                Console.WriteLine("5. List of all available assets");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        manager.AddAsset();
                        Console.Clear();
                        break;

                    case 2:
                        manager.SearchAsset();
                        Console.Clear();
                        break;

                    case 3:
                        manager.UpdateAsset();
                        Console.Clear();
                        break;

                    case 4:
                        manager.DeleteAsset();
                        Console.Clear();
                        break;

                    case 5:
                        manager.ListAllAssets();
                        Console.Clear();
                        break;

                    case 6:
                        running = false;
                        Console.WriteLine("\nThank you for using the system. Goodbye!\n");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please select 1-6.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
*/

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