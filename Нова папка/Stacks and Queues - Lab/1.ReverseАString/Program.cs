using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseАString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{stack.Pop()}");
            }
        }
    }
}
