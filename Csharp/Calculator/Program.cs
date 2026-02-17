using System;

namespace Csharp
{
    class SimpleCalculator
    {
        static void Main()
        {
      
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();  

         
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("   SIMPLE CALCULATOR APP        ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

     
            Console.Write("Enter first number  : ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number : ");
            int number2 = int.Parse(Console.ReadLine());

            Console.Write("Enter operator      : ");
            char operation = char.Parse(Console.ReadLine());

          
            Console.WriteLine("----------------------------");
            switch (operation)
            {
                case '+':
                  
                    Console.WriteLine($"  {number1} + {number2} = {number1 + number2}");
                    break;

                case '-':
                   
                    Console.WriteLine($"  {number1} - {number2} = {number1 - number2}");
                    break;

                case '*':
                   
                    Console.WriteLine($"  {number1} × {number2} = {number1 * number2}");
                    break;

                case '/':
                    if (number2 == 0)
                    {
                      
                        Console.WriteLine("  ✗ Error: Cannot divide by zero!");
                    }
                    else
                    {
                        Console.WriteLine($"  {number1} ÷ {number2} = {number1 / number2}");
                    }
                    break;

                case '%':
                    if (number2 == 0)
                    {
                       
                        Console.WriteLine("  ✗ Error: Cannot modulus by zero!");
                    }
                    else
                    {
                      
                        Console.WriteLine($"  {number1} % {number2} = {number1 % number2}");
                    }
                    break;

                default:
                    
                    Console.WriteLine("Invalid operator! Use +, -, *, /, or %");
                    break;
            }

       
 
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.Write("Press any key to exit...");

            Console.ReadKey();
        }
    }
}