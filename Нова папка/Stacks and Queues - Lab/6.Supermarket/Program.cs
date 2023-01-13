﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket

{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string input = Console.ReadLine();

            while (input !="End")
            {
                if (input!="Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Count>0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }



                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
