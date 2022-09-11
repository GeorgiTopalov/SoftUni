using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = String.Empty;
            int battlesWon = 0;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }
                else
                {
                    battlesWon++;
                    energy -= distance;
                    if (battlesWon % 3 == 0)
                    {
                        energy += battlesWon;
                    }
                }
            }
            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
        }
    }
}
