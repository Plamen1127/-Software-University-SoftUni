using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] inputArray = input.Split();
                string command = inputArray[0];

                if (command == "add")
                {
                    int num1 = int.Parse(inputArray[1]);
                    int num2 = int.Parse(inputArray[2]);
                    stack.Push(num1);
                    stack.Push(num2);
                }

                if (command == "remove")
                {
                    int qryRemove = int.Parse(inputArray[1]);

                    if (stack.Count >= qryRemove)
                    {
                        for (int i = 0; i < qryRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }


                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
