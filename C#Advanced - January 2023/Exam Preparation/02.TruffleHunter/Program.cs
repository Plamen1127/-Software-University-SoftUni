using System;
using System.Drawing;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            string[,] matrix = new string[sizeMatrix, sizeMatrix];

            for (int row = 0; row < sizeMatrix; row++)
            {
                string[] data = Console.ReadLine().Split();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int qtyBlackTruffle = 0;
            int qtySummerTruffle = 0;
            int qtyWhiteTruffle = 0;
            int qtyEatWildBoarTruffel = 0;

            string input = Console.ReadLine();

            while (input != "Stop the hunt")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArray[0];
                int row = int.Parse(inputArray[1]);
                int col = int.Parse(inputArray[2]);

                if (command == "Collect")
                {

                    if (matrix[row, col] == "B")
                    {
                        qtyBlackTruffle++;

                    }
                    else if (matrix[row, col] == "S")
                    {
                        qtySummerTruffle++;
                    }
                    else if (matrix[row, col] == "W")
                    {
                        qtyWhiteTruffle++;
                    }
                    if (matrix[row, col] != "-")
                    {
                        matrix[row, col] = "-";
                    }
                }

                else if (command == "Wild_Boar")
                {
                    string direction = inputArray[3];

                    if (direction == "up")
                    {
                        for (int r = row; r >= 0; r -= 2)
                        {
                            if (matrix[r, col] == "B" || matrix[r, col] == "S" || matrix[r, col] == "W")
                            {
                                matrix[r, col] = "-";
                                qtyEatWildBoarTruffel++;
                            }
                        }

                    }
                    else if (direction == "down")
                    {
                        for (int r = row; r < sizeMatrix; r += 2)
                        {
                            if (matrix[r, col] == "B" || matrix[r, col] == "S" || matrix[r, col] == "W")
                            {
                                matrix[r, col] = "-";
                                qtyEatWildBoarTruffel++;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int c = col; c >= 0; c -= 2)
                        {
                            if (matrix[row, c] == "B" || matrix[row, c] == "S" || matrix[row, c] == "W")
                            {
                                matrix[row, c] = "-";
                                qtyEatWildBoarTruffel++;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int c = col; c < sizeMatrix; c += 2)
                        {
                            if (matrix[row, c] == "B" || matrix[row, c] == "S" || matrix[row, c] == "W")
                            {
                                matrix[row, c] = "-";
                                qtyEatWildBoarTruffel++;
                            }
                        }
                    }
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {qtyBlackTruffle} black, {qtySummerTruffle} summer, and {qtyWhiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {qtyEatWildBoarTruffel} truffles.");
            PrintMatrix<string>(matrix);

        }
        static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
