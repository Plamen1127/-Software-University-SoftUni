using System;
using System.Linq;

namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                }

            }

            int curentRow = 0;
            int curentCol = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        curentRow = row;
                        curentCol = col;
                        matrix[curentRow, curentCol] = '-';
                        break;
                    }
                }

            }

            int mine = 0;
            int cruisersKill = 0;

            while (mine != 3 && cruisersKill != 3)
            {
                matrix[curentRow, curentCol] = '-';

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up": curentRow--; break;
                    case "down": curentRow++; break;
                    case "left": curentCol--; break;
                    case "right": curentCol++; break;
                }


                if (matrix[curentRow, curentCol] == 'C')
                {
                    cruisersKill++;
                }
                else if (matrix[curentRow, curentCol] == '*')
                {
                    mine++;
                }


            }


            matrix[curentRow, curentCol] = 'S';

            if (mine == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{curentRow}, {curentCol}]!");
            }
            else
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }


            PrintMatrix(matrix);

            static void PrintMatrix<T>(T[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}