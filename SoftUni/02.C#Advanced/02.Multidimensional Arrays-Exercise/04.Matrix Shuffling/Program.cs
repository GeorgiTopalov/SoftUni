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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < rowArgs.Length; col++)
                {
                    matrix[row, col] = rowArgs[col];
                }
            }

            string commandArgs = string.Empty;

            while((commandArgs = Console.ReadLine()) != "END")
            {
                string[] commandArgsSplit = commandArgs.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgsSplit[0];

                if (commandArgsSplit.Length == 5)
                {
                    int rowOneCoordinate = int.Parse(commandArgsSplit[1]);
                    int colOneCoordinate = int.Parse(commandArgsSplit[2]);
                    int rowTwoCoordinate = int.Parse(commandArgsSplit[3]);
                    int colTwoCoordinate = int.Parse(commandArgsSplit[4]);

                    if (rowOneCoordinate >= 0 && rowOneCoordinate < rows &&
                        rowTwoCoordinate >= 0 && rowTwoCoordinate < rows &&
                        colOneCoordinate >= 0 && colOneCoordinate < cols &&
                        colTwoCoordinate >= 0 && colTwoCoordinate < cols)
                    {
                        string numToSwap = matrix[rowOneCoordinate, colOneCoordinate];

                        matrix[rowOneCoordinate, colOneCoordinate] = matrix[rowTwoCoordinate, colTwoCoordinate];
                        matrix[rowTwoCoordinate, colTwoCoordinate] = numToSwap;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                        continue;
                    }
                }
                Console.WriteLine("Invalid input!");
            }
          

        }
    }
}