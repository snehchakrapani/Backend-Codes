using System;
using System.Collections;
namespace PracticeCollections
{
    public class ListProgram
    {
        public static void showdata()
        {

            Hashtable employee = new Hashtable();

            employee.Add("EId", 101);
            employee.Add("Name", "Sneh");
            employee.Add("Job", "Developer");
            employee.Add("Location", "jaipur");
            employee.Add("Department", "IT");
            employee.Add("EmailID", "a@a.com");

            employee.Add(123, "Numeric Key");
            employee.Add(true, "Boolean Key");


            foreach (object key in employee.Keys)
            {
                Console.WriteLine(key + " : " + employee[key]);
            }
            Console.WriteLine("Hashtable created with " + employee.Count + " elements");

            bool hasEId = employee.ContainsKey("EId");       
            bool hasDept = employee.ContainsKey("Dept");      

            Console.WriteLine($"Has EId: {hasEId}");
            Console.WriteLine($"Has Dept: {hasDept}");

            bool hasMumbai = employee.ContainsValue("jaipur");      // True
            bool hasTech = employee.ContainsValue("Technology");    // False

            Console.WriteLine($"Has Mumbai: {hasMumbai}");
            Console.WriteLine($"Has Technology: {hasTech}");
        }
    }
}