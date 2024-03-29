﻿using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new List<string>() { "1", "2", "3", "4", "5" });

            Console.WriteLine(stack.IsEmpty());

            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
