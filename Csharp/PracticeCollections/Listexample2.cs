using System;
using System.Collections;

public class ListProgram2
{
	public static void showcity()
	{
        Hashtable cities = new Hashtable()
        {
            { "UK", "London, Manchester, Birmingham" },
            { "USA", "Chicago, New York, Washington" },
            { "India", "Mumbai, Delhi, Bangalore" }
        };

        foreach (DictionaryEntry city in cities)
        {
            Console.WriteLine($"Key: {city.Key}, Value: {city.Value}");
        }
    }
}
