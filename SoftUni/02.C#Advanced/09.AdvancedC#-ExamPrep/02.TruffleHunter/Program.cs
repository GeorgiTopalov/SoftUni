using System;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());

            char[,] forest = new char[area, area];

            for (int row = 0; row < area; row++)
            {
                char[] newRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < area; col++)
                {
                    forest[row, col] = newRow[col];
                }
            }

            string input = string.Empty;

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int boarAte = 0;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);

                if (command == "Collect")
                {

                    switch (forest[row, col])
                    {
                        case 'B':
                            blackTruffles++;
                            break;
                        case 'S':
                            summerTruffles++;
                            break;
                        case 'W':
                            whiteTruffles++;
                            break;
                    }
                    forest[row, col] = '-';

                }
                else
                {
                    string direction = inputArgs[3];


                    if (direction == "up")
                    {
                        for (int rows = row; rows >= 0; rows -= 2)
                        {
                            if (forest[rows, col] == 'B' ||
                                forest[rows, col] == 'S' ||
                                forest[rows, col] == 'W')
                            {
                                forest[rows, col] = '-';
                                boarAte++;
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int rows = row; rows < area; rows += 2)
                        {
                            if (forest[rows, col] == 'B' ||
                               forest[rows, col] == 'S' ||
                               forest[rows, col] == 'W')
                            {
                                forest[rows, col] = '-';
                                boarAte++;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int cols = col; cols >= 0; cols -= 2)
                        {
                            if (forest[row, cols] == 'B' ||
                               forest[row, cols] == 'S' ||
                               forest[row, cols] == 'W')
                            {
                                forest[row, cols] = '-';
                                boarAte++;
                            }
                        }
                    }
                    else
                    {
                        for (int cols = col; cols < area; cols += 2)
                        {
                            if (forest[row, cols] == 'B' ||
                               forest[row, cols] == 'S' ||
                               forest[row, cols] == 'W')
                            {
                                forest[row, cols] = '-';
                                boarAte++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarAte} truffles.");

            for (int i = 0; i < area; i++)
            {
                for (int j = 0; j < area; j++)
                {
                    Console.Write($"{forest[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
