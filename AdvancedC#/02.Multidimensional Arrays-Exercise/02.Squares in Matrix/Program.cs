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

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < rowArgs.Length; col++)
                {
                    matrix[row, col] = rowArgs[col];
                }
            }

            int squaresCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 1 < rows && col + 1 < cols)
                    {
                        char symbolOne = matrix[row, col];
                        char symbolTwo = matrix[row, col + 1];
                        char symbolThree = matrix[row + 1, col + 1];
                        char symbolFour = matrix[row + 1, col];

                        if (symbolOne == symbolTwo &&
                            symbolOne == symbolThree &&
                            symbolOne == symbolFour)
                        {
                            squaresCount++;
                        }

                    }
                }
            }


            Console.WriteLine(squaresCount);
           
        }
    }
}