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

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < rowArgs.Length; col++)
                {
                    matrix[row, col] = rowArgs[col];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 2 < rows && col + 2 < cols)
                    {
                        int currentSum = matrix[row, col] 
                            + matrix[row + 1, col] 
                            + matrix[row + 2, col] 
                            + matrix[row, col + 1] 
                            + matrix[row, col + 2] 
                            + matrix[row + 1, col + 1] 
                            + matrix[row + 1, col + 2] 
                            + matrix[row + 2, col + 1] 
                            + matrix[row + 2, col + 2];

                        

                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            rowIndex = row;
                            colIndex = col;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

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