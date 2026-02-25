using System;
using System.Collections;
namespace PracticeCollections;
public class ListProgram()
{
    Hashtable employee = new Hashtable ();

    employee.Add("EId", 101);
    employee.Add("Name", "Sneh");
    employee.Add("Job", "Developer");
    employee.Add("Location", "jaipur");
    employee.Add("Department", "IT");
    employee.Add("EmailID", "a@a.com");

    employee.Add(123, "Numeric Key");
    employee.Add(true, "Boolean Key");

    foreach (string key in employee.Keys)
    {
        Console.WriteLine(key +" : " + employee[key]);
    }
    Console.WriteLine("Hashtable created with " + employee.Count + " elements");
}