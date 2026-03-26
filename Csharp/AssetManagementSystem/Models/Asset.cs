namespace AssetManagementSystem.Models
{
    public abstract class Asset
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public string? AssignedTo { get; set; }

        public Asset(int serialnumber, string name,
                     DateTime dateOfAcquisition)
        {
            SerialNumber = serialnumber;
            Name = name;
            DateOfAcquisition = dateOfAcquisition;
            AssignedTo = null;
        }

        public abstract string GetAssetType();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Serial Number:    {SerialNumber}");
            Console.WriteLine($"Name:             {Name}");
            Console.WriteLine($"Date of Acquisition: {DateOfAcquisition.ToShortDateString()}");
            Console.WriteLine($"Assigned To:      {AssignedTo ?? "Not Assigned"}");
        }
    }
}