using System;

internal class Program
{
   
    static bool PalindromeAnagram(int number)
    {
        int originalNumber = number;
        int reversedNumber = 0;

        while (number > 0)
        {
            int lastDigit = number % 10;
            reversedNumber = reversedNumber * 10 + lastDigit;
            number = number / 10;
        }

        return originalNumber == reversedNumber;
    }

    static string GetSortedDigits(int number)
    {
        char[] digitCharArray = number.ToString().ToCharArray();
        Array.Sort(digitCharArray);
        return new string(digitCharArray);
    }

    static void Main()
    {
        int[] numbers = { 12, 21, 121, 131, 45, 54, 1331 };

        int totalPalindromes = 0;
        int highestPalindrome = -1;
        int totalAnagramPairs = 0;

       
        for (int i = 0; i < numbers.Length; i++)
        {
            if (PalindromeAnagram(numbers[i]))
            {
                totalPalindromes++;

                if (numbers[i] > highestPalindrome)
                {
                    highestPalindrome = numbers[i];
                }
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (GetSortedDigits(numbers[i]) == GetSortedDigits(numbers[j]))
                {
                    totalAnagramPairs++;
                }
            }
        }

  
        Console.WriteLine("Total Anagram Pairs: " + totalAnagramPairs);
        Console.WriteLine("Total Palindromes: " + totalPalindromes);
        Console.WriteLine("Highest Palindrome: " + highestPalindrome);
    }
}