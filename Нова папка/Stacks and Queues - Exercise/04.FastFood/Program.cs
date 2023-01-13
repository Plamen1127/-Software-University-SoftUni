using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtyFood = int.Parse(Console.ReadLine());

            Queue<int> queuekOrders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(queuekOrders.Max());



            while (queuekOrders.Count > 0)
            {
                int curentOreder = queuekOrders.Peek();
                if (qtyFood >= curentOreder)
                {
                    qtyFood -= curentOreder;
                    queuekOrders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queuekOrders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
          

        }
    }
}
