using System;

class Program
{
    static void Main()
    {
        string sentence = "My organization name is InTimeTEC";

        sentence = sentence.ToLower();

        string[] words = sentence.Split(' ');

        Console.WriteLine("The total word count in the given sentence is: " + words.Length);

        Console.Write("The reversed order of the given sentence : ");

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            for (int j = word.Length - 1; j >= 0; j--)
            {
                Console.Write(word[j]);
            }

            if (i != words.Length - 1)
            {
                Console.Write(" ");
            }
        }

        Console.Write(".");
    }
}