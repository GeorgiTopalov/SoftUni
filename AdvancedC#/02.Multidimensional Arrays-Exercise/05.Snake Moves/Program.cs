using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];
            int charCoordinates = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (charCoordinates == snake.Length)
                        {
                            charCoordinates = 0;
                        }
                        matrix[row, col] = snake[charCoordinates];
                        charCoordinates++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (charCoordinates == snake.Length)
                        {
                            charCoordinates = 0;
                        }
                        matrix[row, col] = snake[charCoordinates];
                        charCoordinates++;
                    }
                }
               
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}