using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());

            char[,] pond = new char[area, area];
            int beaverRow = 0;
            int beaverCol = 0;
            int totalBranches = 0;

            for (int row = 0; row < area; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < area; col++)
                {
                    pond[row, col] = currentRow[col];
                    if (currentRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (Char.IsLetter(currentRow[col]) && Char.IsLower(currentRow[col]))
                    {
                        totalBranches++;
                    }
                }
            }

            string command = string.Empty;
            List<char> branches = new List<char>();

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "down")
                {
                    if (beaverRow + 1 < area)
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow++;

                        if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            if (beaverRow + 1 != 0)
                            {
                                beaverRow = 0;
                            }
                            else
                            {
                                beaverRow = area - 1;
                            }
                        }
                        if (Char.IsLetter(pond[beaverRow, beaverCol]) &&
                            Char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branches.Add(pond[beaverRow, beaverCol]);
                            totalBranches--;
                        }

                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "up")
                {
                    if (beaverRow - 1 >= 0)
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow--;

                        if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';

                            if (beaverRow - 1 != 0)
                            {
                                beaverRow = area - 1;
                            }
                            else
                            {
                                beaverRow = 0;
                            }
                            if (Char.IsLetter(pond[beaverRow, beaverCol]) &&
                            Char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                                totalBranches--;
                            }
                        }
                        else if (Char.IsLetter(pond[beaverRow, beaverCol]) &&
                            Char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branches.Add(pond[beaverRow, beaverCol]);
                            totalBranches--;
                        }

                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    if (beaverCol - 1 >= 0)
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol--;

                        if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            if (beaverCol - 1 != 0)
                            {
                                beaverCol = area - 1;
                            }
                            else
                            {
                                beaverCol = 0;
                            }
                        }
                        if (Char.IsLetter(pond[beaverRow, beaverCol]) &&
                            Char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branches.Add(pond[beaverRow, beaverCol]);
                            totalBranches--;
                        }


                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else
                {
                    if (beaverCol + 1 < area)
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol++;

                        if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            if (beaverCol + 1 != 0)
                            {
                                beaverCol = area - 1;
                            }
                            else
                            {
                                beaverCol = 0;
                            }
                        }
                        if (Char.IsLetter(pond[beaverRow, beaverCol]) &&
                            Char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branches.Add(pond[beaverRow, beaverCol]);
                            totalBranches--;
                        }

                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }

                pond[beaverRow, beaverCol] = 'B';

                if (totalBranches == 0)
                {
                    break;
                }
            }

            if (totalBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
            }

            for (int i = 0; i < area; i++)
            {
                for (int j = 0; j < area; j++)
                {
                    Console.Write($"{pond[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
