using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> queueData = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                queueData.Enqueue($"{i} " + Console.ReadLine());
            }

            int amount = 0;

            for (int i = 0; i < queueData.Count; i++)
            {
                string[] curentData = queueData.Dequeue().Split();
                int fuel = int.Parse(curentData[1]);
                int distans = int.Parse(curentData[2]);

                amount += fuel;

                if (amount >= distans)
                {
                    amount -= distans;
                }
                else
                {
                    amount = 0;
                    i = -1;
                }

                queueData.Enqueue(string.Join(" ", curentData));
            }
            Console.WriteLine(queueData.Dequeue().Split()[0]);
        }
    }
}