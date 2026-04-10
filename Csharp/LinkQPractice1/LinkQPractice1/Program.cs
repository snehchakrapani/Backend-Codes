using LinkQPractice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkQPractice1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student { ID=1, Name="sneh",  Gender="Male",   City="Mumbai", Marks=85, Salary=8000 },
                new Student { ID=2, Name="Priyanka", Gender="Female", City="London", Marks=72, Salary=5000 },
                new Student { ID=3, Name="Anurag",   Gender="Male",   City="Mumbai", Marks=91, Salary=7000 },
                new Student { ID=4, Name="Kunal",   Gender="Female", City="Delhi",  Marks=60, Salary=4000 },
                new Student { ID=5, Name="Hina",     Gender="Female", City="London", Marks=78, Salary=9000 },
                new Student { ID=6, Name="Nakul",    Gender="Male",   City="Delhi",  Marks=55, Salary=6000 }
            };

           
            Console.WriteLine("1. QUERY SYNTAX - Males");
        
            var querySyntax = from s in students
                              where s.Gender == "Male"
                              select s;
            foreach (var s in querySyntax)
                Console.WriteLine($"ID={s.ID}, Name={s.Name}, Gender={s.Gender}");


            Console.WriteLine("\n2. METHOD SYNTAX - Salary > 6000");
           
            var methodSyntax = students.Where(s => s.Salary > 6000);
            foreach (var s in methodSyntax)
                Console.WriteLine($"Name={s.Name}, Salary={s.Salary}");

          
            Console.WriteLine("\n3. MIXED SYNTAX - Sum of Marks > 70");
           
            var mixedSyntax = (from s in students
                               where s.Marks > 70
                               select s).Sum(s => s.Marks);
            Console.WriteLine($"Sum of Marks > 70: {mixedSyntax}");

       
            Console.WriteLine("\n4. ORDER BY - Marks Ascending");
           
            var sortedAsc = students.OrderBy(s => s.Marks);
            foreach (var s in sortedAsc)
                Console.WriteLine($"Name={s.Name}, Marks={s.Marks}");

            Console.WriteLine("\nMarks Descending ");
            var sortedDesc = students.OrderByDescending(s => s.Marks);
            foreach (var s in sortedDesc)
                Console.WriteLine($"Name={s.Name}, Marks={s.Marks}");

            Console.WriteLine("\n5. SELECT - Names Only");
            
            var namesOnly = students.Select(s => s.Name);
            foreach (var name in namesOnly)
                Console.WriteLine(name);

           
            Console.WriteLine("\n6. Other METHODS");
           
            Console.WriteLine($"Total Students : {students.Count()}");
            Console.WriteLine($"Total Salary   : {students.Sum(s => s.Salary)}");
            Console.WriteLine($"Average Marks  : {students.Average(s => s.Marks)}");
            Console.WriteLine($"Highest Marks  : {students.Max(s => s.Marks)}");
            Console.WriteLine($"Lowest Marks   : {students.Min(s => s.Marks)}");


            Console.WriteLine("\n8. GROUP BY - By City");
        
            var groupByCity = students.GroupBy(s => s.City);
            foreach (var group in groupByCity)
            {
                Console.WriteLine($"\nCity: {group.Key}");
                foreach (var s in group)
                    Console.WriteLine($"   -> {s.Name}");
            }

          
            Console.WriteLine("\n9. DISTINCT Cities");
         
            var distinctCities = students.Select(s => s.City).Distinct();
            foreach (var city in distinctCities)
                Console.WriteLine(city);


            Console.WriteLine("\n11. ToList & ToArray");
          
            List<Student> maleList = students.Where(s => s.Gender == "Male").ToList();
            Console.WriteLine($"Male List Count   : {maleList.Count}");
            Student[] femaleArray = students.Where(s => s.Gender == "Female").ToArray();
            Console.WriteLine($"Female Array Length: {femaleArray.Length}");

        
          
            Console.ReadKey();
        }
    }
}