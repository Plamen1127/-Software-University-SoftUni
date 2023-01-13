using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> openingBrackets = new Stack<string>();
            string input = Console.ReadLine();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                string bracket = input[i].ToString();

                if (bracket == "[" ||
                    bracket == "{" ||
                    bracket == "(")
                {
                    openingBrackets.Push(bracket);
                }
                else if (openingBrackets.Count > 0)
                {

                    string brackets = openingBrackets.Peek() + bracket;

                    if (brackets != "{}" && brackets != "[]" && brackets != "()")
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        openingBrackets.Pop();
                    }
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
