using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sumLeftDiagonal = 0;
            int sumRightDiagonal = 0;

            for (int row = 0; row < size; row++)
            {
                sumLeftDiagonal += matrix[row, row];
            }

            for (int row = size-1; row >= 0; row--)
            {
                sumRightDiagonal += matrix[row, size-1-row];

            }

            Console.WriteLine(Math.Abs(sumRightDiagonal-sumLeftDiagonal));

        }
    }
}