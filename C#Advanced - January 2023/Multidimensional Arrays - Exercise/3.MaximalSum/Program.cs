using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < size[0] - 2; row++)
            {
                for (int col = 0; col < size[1] - 2; col++)
                {
                    int curentSum = 0;
                    curentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                               + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                               + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (curentSum > sum)
                    {
                        sum = curentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($" Sum = {sum}");

            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();

            }
        }
    }
}
