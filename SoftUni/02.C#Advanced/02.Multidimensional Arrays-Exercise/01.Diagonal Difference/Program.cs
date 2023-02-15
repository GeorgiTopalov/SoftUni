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
            int input = int.Parse(Console.ReadLine());


            int rows = input;
            int cols = input;

            int[,] matrixToSum = new int[rows, cols];

            for (int row = 0; row < matrixToSum.GetLength(0); row++)
            {
                int[] rowArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < rowArgs.Length; col++)
                {
                    matrixToSum[row, col] = rowArgs[col];
                }
            }

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < rows; i++)
            {
                leftSum += matrixToSum[i, i];
                rightSum += matrixToSum[i, rows - 1 - i];
            }


            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}