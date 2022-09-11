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
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = ReadJaggedArray(rows);

            for (int i = 1; i < jagged.Length; i++)
            {
                if (jagged[i].Length == jagged[i - 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] = jagged[i][j] * 2;
                        jagged[i - 1][j] = jagged[i - 1][j] * 2;
                    }
                }
                else
                {
                    int longerOfTwo = 0;

                    if (jagged[i].Length > jagged[i - 1].Length || jagged[i].Length == jagged[i - 1].Length)
                    {
                        longerOfTwo = jagged[i].Length;

                    }
                    else
                    {
                        longerOfTwo = jagged[i-1].Length;

                    }
                    for (int j = 0; j < longerOfTwo; j++)
                    {
                        if (j < jagged[i].Length)
                        jagged[i][j] = jagged[i][j] / 2;

                        if (j < jagged[i - 1].Length)
                        {
                            jagged[i - 1][j] = jagged[i - 1][j] / 2;

                        }
                    }
                }

            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    continue;
                }
                else if (command[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else
                {
                    jagged[row][col] -= value;

                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }

        }

        static int[][] ReadJaggedArray(int rows)
        {
            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            return jagged;
        }
    }
}