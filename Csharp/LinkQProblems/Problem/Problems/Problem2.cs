using Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;

/*Problem statement 2: Write a LINQ query to select the nth element from a list of objects, 
 * where n is a variable passed to the query.
*/

namespace Problem.Problems
{
    public class Problem2
    { 
        public static void Run()
        {
            Console.WriteLine("\n=== PROBLEM 2: Get Nth Element ===");

            List<Student> students = new List<Student>()
            {
                new Student { ID = 1, Name = "Nakul"  },
                new Student { ID = 2, Name = "Saksham" },
                new Student { ID = 3, Name = "Anurag"   },
                new Student { ID = 4, Name = "Jeet"   },
                new Student { ID = 5, Name = "Hina"     }
            };

            int n = 3;

            var result = students.ElementAtOrDefault(n - 1);
            Console.WriteLine($"{n}rd Student: ID={result?.ID}, Name={result?.Name}");

            var outOfRange = students.ElementAtOrDefault(10 - 1);
            Console.WriteLine($"10th Student: {(outOfRange == null ? "Not Found!" : outOfRange.Name)}");
        }
    }
}