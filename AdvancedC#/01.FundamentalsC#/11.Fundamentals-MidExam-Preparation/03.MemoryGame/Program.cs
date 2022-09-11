using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> memorySequence = Console.ReadLine().Split().ToList();
            string input = String.Empty;

            int moves = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] guess = input.Split();
                int firstGuess = int.Parse(guess[0]);
                int secondGuess = int.Parse(guess[1]);
                moves++;

                if ((firstGuess == secondGuess) || (firstGuess > memorySequence.Count) || (secondGuess > memorySequence.Count) || (firstGuess < 0) || (secondGuess < 0))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string addedElements = moves.ToString();
                    memorySequence.Insert((memorySequence.Count / 2), $"-{addedElements}a");
                    memorySequence.Insert((memorySequence.Count / 2), $"-{addedElements}a");

                }
                else if (memorySequence[firstGuess] == memorySequence[secondGuess])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {memorySequence[firstGuess]}!");

                    if (memorySequence.Count == 2)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        return;
                    }
                    if (firstGuess < secondGuess)
                    {
                        memorySequence.RemoveAt(firstGuess);
                        memorySequence.RemoveAt(secondGuess - 1);
                    }
                    else
                    {
                        memorySequence.RemoveAt(firstGuess);
                        memorySequence.RemoveAt(secondGuess);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(String.Join(' ', memorySequence));
        }
    }
}
