using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());

            char[][] matrix = new char[area][];


            for (int row = 0; row < area; row++)
            {
                char[] newRow = Console.ReadLine().Where(x => !Char.IsWhiteSpace(x)).ToArray();
                matrix[row] = newRow;
            }

            string input = String.Empty;
            int tokensCollected = 0;
            int opponentsTokens = 0;

            

            while ((input = Console.ReadLine()) != "Gong")
            {

                string command = input.Split()[0];
                int rowPosition = int.Parse(input.Split()[1]);
                int colPosition = int.Parse(input.Split()[2]);

                if (rowPosition < 0 || rowPosition >= area || colPosition < 0 || colPosition >= matrix[rowPosition].Length)
                {
                    continue;
                }

                if (command == "Find")
                {
                    if (matrix[rowPosition][colPosition] == 'T')
                    {
                        matrix[rowPosition][colPosition] = '-';
                        tokensCollected++;
                    }
                }
                else
                {
                    string direction = input.Split()[3];
                    int counter = 0;

                    if (direction == "up")
                    {
                        
                        for (int i = rowPosition; i >= 0; i--)
                        {
                            
                            if (counter == 4)
                            {
                                break;
                            }
                            if (matrix[i][colPosition] == 'T')
                            {
                                opponentsTokens++;
                            }
                            counter++;
                            matrix[i][colPosition] = '-';
                        }

                    }
                    else if (direction == "down")
                    {
                        for (int i = rowPosition; i < area; i++)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (matrix[i][colPosition] == 'T')
                            {
                                opponentsTokens++;
                            }
                            counter++;
                            matrix[i][colPosition] = '-';
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = colPosition; i >= 0; i--)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (matrix[rowPosition][i] == 'T')
                            {
                                opponentsTokens++;
                            }
                            counter++;
                            matrix[rowPosition][i] = '-';
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = colPosition; i < matrix[rowPosition].Length; i++)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (matrix[rowPosition][i] == 'T')
                            {
                                opponentsTokens++;
                            }
                            counter++;
                            matrix[rowPosition][i] = '-';
                        }
                    }
                }
            }


            for (int i = 0; i < area; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }

            Console.WriteLine($"Collected tokens: {tokensCollected}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");

        }
    }
}
