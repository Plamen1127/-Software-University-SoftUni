using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<string> text = new Stack<string>();
            text.Push("");

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string crnText = text.Peek();

                switch (command)
                {
                    case "1":
                        crnText += input[1];
                        text.Push(crnText);
                        break;

                    case "2":
                        int n = int.Parse(input[1]);
                        text.Push(crnText.Substring(0, crnText.Length - n));
                        break;

                    case "3":
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(crnText.Substring(index, 1));
                        break;

                    case "4":
                        text.Pop();
                        break;
                }
            }
        }
    }
}
