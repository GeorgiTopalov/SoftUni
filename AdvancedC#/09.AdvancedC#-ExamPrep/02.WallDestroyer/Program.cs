using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallArea = int.Parse(Console.ReadLine());
            int rows = wallArea;
            int cols = wallArea;
            char[,] wall = new char[rows, cols];

            int vankosPositionRow = 0;
            int vankosPositionCol = 0;

            for (int i = 0; i < rows; i++)
            {
                string newRow = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    wall[i, j] = newRow[j];

                    if (newRow[j] == 'V')
                    {
                        vankosPositionRow = i;
                        vankosPositionCol = j;
                        wall[i, j] = '*';
                    }
                }
            }

           

            string input = string.Empty;
            bool isElectricuted = false;
            int holesMade = 1;
            int rodsHit = 0;

            while((input = Console.ReadLine()) != "End")
            {
                if (input == "up")
                {
                    if (vankosPositionRow > 0)
                    {
                        if (wall[vankosPositionRow - 1, vankosPositionCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankosPositionRow - 1}, {vankosPositionCol}]!");
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            vankosPositionRow--;
                        }
                        else if (wall[vankosPositionRow - 1, vankosPositionCol] == 'R')
                        {
                            rodsHit++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankosPositionRow - 1, vankosPositionCol] == 'C')
                        {
                            wall[vankosPositionRow - 1, vankosPositionCol] = 'E';
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            isElectricuted = true;
                            break;
                        }
                        else
                        {
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            vankosPositionRow--;
                        }
                    }
                }
                else if (input == "down")
                {
                    if (vankosPositionRow < rows - 1)
                    {
                        if (wall[vankosPositionRow + 1, vankosPositionCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankosPositionRow + 1}, {vankosPositionCol}]!");
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            vankosPositionRow++;
                        }
                        else if (wall[vankosPositionRow + 1, vankosPositionCol] == 'R')
                        {
                            rodsHit++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankosPositionRow + 1, vankosPositionCol] == 'C')
                        {
                            wall[vankosPositionRow + 1, vankosPositionCol] = 'E';
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            isElectricuted = true;
                            break;
                        }
                        else
                        {
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            vankosPositionRow++;
                        }
                    }
                }
                else if (input == "left")
                {
                    if (vankosPositionCol > 0)
                    {
                        if (wall[vankosPositionRow, vankosPositionCol - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankosPositionRow}, {vankosPositionCol - 1}]!");
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            vankosPositionCol--;
                        }
                        else if (wall[vankosPositionRow, vankosPositionCol - 1] == 'R')
                        {
                            rodsHit++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankosPositionRow, vankosPositionCol - 1] == 'C')
                        {
                            wall[vankosPositionRow, vankosPositionCol - 1] = 'E';
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            isElectricuted = true;
                            break;
                        }
                        else
                        {
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            vankosPositionCol--;
                        }
                    }
                }
                else if (input == "right")
                {
                    if (vankosPositionCol < rows - 1)
                    {
                        if (wall[vankosPositionRow, vankosPositionCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankosPositionRow}, {vankosPositionCol + 1}]!");
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            vankosPositionCol++;
                        }
                        else if (wall[vankosPositionRow, vankosPositionCol + 1] == 'R')
                        {
                            rodsHit++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankosPositionRow, vankosPositionCol + 1] == 'C')
                        {
                            wall[vankosPositionRow, vankosPositionCol + 1] = 'E';
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            isElectricuted = true;
                            break;
                        }
                        else
                        {
                            wall[vankosPositionRow, vankosPositionCol] = '*';
                            holesMade++;
                            vankosPositionCol++;
                        }
                    }
                }

                wall[vankosPositionRow, vankosPositionCol] = 'V';
            }

            if (!isElectricuted)
            {
                Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(wall[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
