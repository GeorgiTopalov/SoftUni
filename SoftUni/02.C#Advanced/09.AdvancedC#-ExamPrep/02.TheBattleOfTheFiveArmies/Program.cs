using System;

namespace _02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            
            int armyRow = 0;
            int armyCol = 0;
            
            char[][] middleEarth = new char[area][];

            for (int row = 0; row < area; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                middleEarth[row] = currentRow;

                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (armor > 0)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);

                middleEarth[orcRow][orcCol] = 'O';
                middleEarth[armyRow][armyCol] = '-';

                
                
                if (command == "up" && armyRow != 0)
                {
                    armyRow--;
                }
                else if (command == "down" && armyRow != area - 1)
                {
                    armyRow++;
                }
                else if (command == "left" && armyCol != 0)
                {
                    armyCol--;
                }
                else if (command == "right" && armyCol != middleEarth[armyRow].Length - 1)
                {
                    armyCol++;
                }

                armor--;

                        if (middleEarth[armyRow][armyCol] == 'M')
                        {
                            middleEarth[armyRow][armyCol] = '-';

                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            break;
                        }
                        else if (armor <= 0)
                        {
                            Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                            middleEarth[armyRow][armyCol] = 'X';
                            break;
                        }
                        else if (middleEarth[armyRow][armyCol] == 'O')
                        {
                            if (armor - 2 > 0)
                            {
                                armor -= 2;
                                middleEarth[armyRow][armyCol] = 'A';
                            }
                            else
                            {
                                middleEarth[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                        }

            }

            for (int i = 0; i < area; i++)
            {
                Console.WriteLine(String.Join("", middleEarth[i]));
            }
        }
    }
}



