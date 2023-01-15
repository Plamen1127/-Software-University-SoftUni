using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaggaeArray = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jaggaeArray[row] = new long[row + 1];

                for (int col = 0; col <= row; col++)
                {
                    if (col == 0)
                    {
                        jaggaeArray[row][col] = 1;
                    }
                    else if (row == col)
                    {
                        jaggaeArray[row][col] = 1;
                    }
                    else
                    {
                        jaggaeArray[row][col] = jaggaeArray[row - 1][col] + jaggaeArray[row - 1][col - 1];
                    }

                }

            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jaggaeArray[row].Length; col++)
                {
                    Console.Write($"{jaggaeArray[row][col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
