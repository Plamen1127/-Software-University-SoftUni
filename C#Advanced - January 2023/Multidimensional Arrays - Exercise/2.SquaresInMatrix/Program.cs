using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] charecters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x =>char.Parse(x))
                    .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = charecters[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < size[0]-1; row++)
            {
                for (int col = 0; col < size[1]-1; col++)
                {
                    if(matrix[row,col] == matrix[row, col +1] 
                        && matrix[row, col] == matrix[row+1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
