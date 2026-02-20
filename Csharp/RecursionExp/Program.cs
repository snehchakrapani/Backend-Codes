using System;

class Program
{
    static void Main()
    {
        int number = 5;
        int result = Sum(number);
        Console.WriteLine($"Sum of 1 to {number} is {result}");
        Console.ReadKey();
    }

    static int Sum(int n)
    {
        if (n > 0)
        {
            return Sum(n - 1) + n; 
        }
        return 0;  
    }
}
/*  static int Factorial(int n)
    {
        if (n == 1)   Base case
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);   Recursive case
        }
    }*/
/*  static int Fibonacci(int n)
    {
        if (n == 0)   Base case
        {
            return 0;
        }
        else if (n == 1)   Base case
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);   Recursive case
        }
    }
*/
/*
    static string Reverse(string str)
    {
        if (str.Length <= 1)
            return str;  
        
        return Reverse(str.Substring(1)) + str[0];
    }
}
*/