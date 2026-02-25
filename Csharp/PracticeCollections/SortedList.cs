using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeCollections
{
   public class SortedListDemo
    {
       public static  void ShowSortedList()
        {
            SortedList sortedList = new SortedList();

            sortedList.Add(3, "Three");
            sortedList.Add(1, "One");
            sortedList.Add(5, "Five");
            sortedList.Add(2, "Two");
            sortedList.Add(4, "Four");
            sortedList.Add(6, null);


            Console.WriteLine("\nACCESS USING FOREACH");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine("\nACCESS USING KEY");
            Console.WriteLine($"Value of Key 1: {sortedList[1]}");

            Console.WriteLine("\nACCESS USING INDEX");
            Console.WriteLine($"Element at Index 0: {sortedList.GetByIndex(0)}");

            Console.WriteLine("\nCHECKING EXISTENCE");
            Console.WriteLine("Contains Key 3: " + sortedList.ContainsKey(3));
            Console.WriteLine("Contains Value 'Five': " + sortedList.ContainsValue("Five"));
            Console.WriteLine("Contains Key 10: " + sortedList.Contains(10));

            Console.WriteLine("\nREMOVE BY KEY (2)");
            sortedList.Remove(2);

            Console.WriteLine("\nREMOVE BY INDEX (0)");
            sortedList.RemoveAt(0);

            Console.WriteLine("\nAfter Removals:");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine("\nCLONING SORTEDLIST");
            SortedList cloneList = (SortedList)sortedList.Clone();
            foreach (DictionaryEntry item in cloneList)
            {
                Console.WriteLine($"Cloned Key: {item.Key}, Value: {item.Value}");
            }

      

            Console.WriteLine("\nPROPERTIES");
            Console.WriteLine("Count: " + sortedList.Count);
            Console.WriteLine("Capacity: " + sortedList.Capacity);
            Console.WriteLine("IsReadOnly: " + sortedList.IsReadOnly);
            Console.WriteLine("IsFixedSize: " + sortedList.IsFixedSize);
            Console.WriteLine("IsSynchronized: " + sortedList.IsSynchronized);

            Console.WriteLine("\nKEYS COLLECTION");
            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\nVALUES COLLECTION");
            foreach (var value in sortedList.Values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nCLEARING SORTEDLIST");
            sortedList.Clear();
            Console.WriteLine("Total elements after Clear: " + sortedList.Count);

            Console.ReadKey();
        }
    }
}
