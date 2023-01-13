using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            int tosses = 1;

            while (queue.Count > 1)
            {
                string curentKind = queue.Dequeue();
                if (tosses == n)
                {
                    Console.WriteLine($"Removed {curentKind}");
                    tosses = 1;
                    continue;
                }

                tosses++;
                queue.Enqueue(curentKind);

            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
