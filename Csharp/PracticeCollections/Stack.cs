using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeCollections
{
    
      
public class StackDemo
    {
      public static void Showfun()
        {
            Console.WriteLine(" CREATING STACK ");
            Stack stack = new Stack();

            
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.WriteLine($"Total elements: {stack.Count}");

            Console.WriteLine("\n ALL ELEMENTS (Top to Bottom) ");
            foreach (object item in stack)
            {
                Console.Write($"{item} ");
            }

          
            object topElement = stack.Peek();
            Console.WriteLine($"Top element: {topElement}");
            Console.WriteLine($"Count after Peek: {stack.Count}");

            Console.WriteLine("\n POP (Remove Top) ");
            object popped1 = stack.Pop();
            Console.WriteLine($"Popped: {popped1}");
            Console.WriteLine($"Count after Pop: {stack.Count}");

            object popped2 = stack.Pop();
            Console.WriteLine($"Popped: {popped2}");
            Console.WriteLine($"Count after Pop: {stack.Count}");

            Console.WriteLine("\n REMAINING ELEMENTS ");
            foreach (object item in stack)
            {
                Console.Write($"{item} ");
            }

          
            Console.WriteLine($"Contains 30: {stack.Contains(30)}");
            Console.WriteLine($"Contains 50: {stack.Contains(50)}");

            Console.WriteLine("\n CLEAR ALL ");
            stack.Clear();
            Console.WriteLine($"Count after Clear: {stack.Count}");

            Console.ReadKey();
        }
    }
}

