using System;

internal class Program
{
    static void Main()
    {
        int totalRows = 5;

  
        for (int i = totalRows; i >= 1; i--)
        {
            
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }

       
            Console.WriteLine();
        }
    }
}