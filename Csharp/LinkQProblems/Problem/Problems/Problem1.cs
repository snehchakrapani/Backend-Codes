using System;
using System.Collections.Generic;
using System.Text;

/*Problem statement 1: Write a LINQ query to select 
 * all distinct characters from a list of strings and return them in alphabetical order.*/

namespace Problem.Problems
{
    public  class Problem1
    {
        public static void Run()
        {
            Console.WriteLine("===== Problem 1: Distinct charactesr alphabatically");

            List<string> words = new List<string>()
            {
"sneh", "nakul", "chaitanya", "archana", "deepak", "riya"
            };

            var result = words
                .SelectMany(words => words)
                .Distinct()
                .OrderBy(c=>c)
                .ToList();

            Console.Write("RESULT: ");
            foreach(var c in result)
            {
                Console.Write(c + " ");
                Console.WriteLine();
            }
        }
    }
}
