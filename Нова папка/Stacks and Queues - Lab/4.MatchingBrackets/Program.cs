using System;
using System.Collections;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expession = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expession.Length; i++)
            {
                if (expession[i] == '(')
                {
                    stack.Push(i);
                }

                if (expession[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(expession.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
