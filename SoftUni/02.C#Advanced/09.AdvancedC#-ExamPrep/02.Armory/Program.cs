using System;
using System.Linq;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());

            char[,] armory = new char[area, area];

            int armyOfficerRow = 0;
            int armyOfficerCol = 0;
            int firstMirrowRow = 0;
            int firstMirrorCol = 0;
            int secondMirrowRow = 0;
            int secondMirrowCol = 0;
            int mirrorsCount = 0;

            for (int row = 0; row < area; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < area; col++)
                {
                    armory[row,col] = newRow[col];

                    if (newRow[col] == 'A')
                    {
                        armyOfficerRow = row;
                        armyOfficerCol = col;
                    }
                    if ((newRow[col] == 'M') && (mirrorsCount == 0))
                    {
                        firstMirrowRow = row;
                        firstMirrorCol = col;
                    }
                    else if ((newRow[col] == 'M'))
                    {
                        secondMirrowRow = row;
                        secondMirrowCol = col;

                    }

                }
            }

            int coinsSpent = 0;

            while (coinsSpent < 65)
            {
                string command = Console.ReadLine();

                armory[armyOfficerRow, armyOfficerCol] = '-';

                if (command == "up")
                {
                    if (armyOfficerRow - 1 < 0)
                    {
                        break;
                    }
                    else if (Char.IsDigit(armory[armyOfficerRow - 1, armyOfficerCol]))
                    {
                        string swordCost = armory[armyOfficerRow - 1, armyOfficerCol].ToString();
                        coinsSpent += int.Parse(swordCost);
                        armyOfficerRow--;
                    }
                    else if (armory[armyOfficerRow - 1, armyOfficerCol] == 'M') 
                    {
                        armory[armyOfficerRow - 1, armyOfficerCol] = '-';

                        if ((armyOfficerRow - 1 == firstMirrowRow) && (armyOfficerCol == firstMirrorCol))
                        {
                            armyOfficerRow = secondMirrowRow;
                            armyOfficerCol = secondMirrowCol;
                        }
                        else
                        {
                            armyOfficerRow = firstMirrowRow;
                            armyOfficerCol = firstMirrorCol;
                        }
                    }
                    else
                    {
                        armyOfficerRow--;
                    }
                }
                else if (command == "down")
                {
                    if (armyOfficerRow + 1 > area - 1)
                    {
                        break;
                    }
                    else if (Char.IsDigit(armory[armyOfficerRow + 1, armyOfficerCol]))
                    {
                        string swordCost = armory[armyOfficerRow + 1, armyOfficerCol].ToString();
                        coinsSpent += int.Parse(swordCost);
                        armyOfficerRow++;
                    }
                    else if (armory[armyOfficerRow + 1, armyOfficerCol] == 'M')
                    {
                        armory[armyOfficerRow + 1, armyOfficerCol] = '-';

                        if ((armyOfficerRow + 1 == firstMirrowRow) && (armyOfficerCol == firstMirrorCol))
                        {
                            armyOfficerRow = secondMirrowRow;
                            armyOfficerCol = secondMirrowCol;
                        }
                        else
                        {
                            armyOfficerRow = firstMirrowRow;
                            armyOfficerCol = firstMirrorCol;
                        }
                    }
                    else
                    {
                        armyOfficerRow++;
                    }
                }
                else if (command == "left")
                {
                    if (armyOfficerCol - 1 < 0)
                    {
                        break;
                    }
                    else if (Char.IsDigit(armory[armyOfficerRow, armyOfficerCol - 1]))
                    {
                        string swordCost = armory[armyOfficerRow, armyOfficerCol - 1].ToString();
                        coinsSpent += int.Parse(swordCost);
                        armyOfficerCol--;
                    }
                    else if (armory[armyOfficerRow, armyOfficerCol - 1] == 'M')
                    {
                        armory[armyOfficerRow, armyOfficerCol - 1] = '-';

                        if ((armyOfficerRow == firstMirrowRow) && (armyOfficerCol - 1 == firstMirrorCol))
                        {
                            armyOfficerRow = secondMirrowRow;
                            armyOfficerCol = secondMirrowCol;
                        }
                        else
                        {
                            armyOfficerRow = firstMirrowRow;
                            armyOfficerCol = firstMirrorCol;
                        }
                    }
                    else
                    {
                        armyOfficerCol--;
                    }
                }
                else
                {
                    if (armyOfficerCol +1 > area - 1)
                    {
                        break;
                    }
                    else if (Char.IsDigit(armory[armyOfficerRow, armyOfficerCol + 1]))
                    {
                        string swordCost = armory[armyOfficerRow, armyOfficerCol + 1].ToString();
                        coinsSpent += int.Parse(swordCost);
                        armyOfficerCol++;
                    }
                    else if (armory[armyOfficerRow, armyOfficerCol + 1] == 'M')
                    {
                        armory[armyOfficerRow, armyOfficerCol + 1] = '-';

                        if ((armyOfficerRow == firstMirrowRow) && (armyOfficerCol + 1 == firstMirrorCol))
                        {
                            armyOfficerRow = secondMirrowRow;
                            armyOfficerCol = secondMirrowCol;
                        }
                        else
                        {
                            armyOfficerRow = firstMirrowRow;
                            armyOfficerCol = firstMirrorCol;
                        }
                    }
                    else
                    {
                        armyOfficerCol++;
                    }
                }

                armory[armyOfficerRow, armyOfficerCol] = 'A';
            }

            if (coinsSpent < 65)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {coinsSpent} gold coins.");

            for (int i = 0; i < area; i++)
            {
                for (int j = 0; j < area; j++)
                {
                    Console.Write($"{armory[i, j]}"); 
                }
                Console.WriteLine();
            }
        }
    }
}
