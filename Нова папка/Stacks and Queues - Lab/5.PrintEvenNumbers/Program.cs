using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            while (queue.Count>0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    Console.Write($"{queue.Dequeue()}");
                    if (queue.Count()>0)
                    {
                        Console.Write($", ");
                    }
                    
                }
                else
                {
                    queue.Dequeue();
                }

               
            }
        }
    }
}
