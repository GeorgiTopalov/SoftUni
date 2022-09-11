using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighbourhood = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string jumpCommand = String.Empty;
            int currentLocation = 0;
            int housesOfLove = 0;
            while ((jumpCommand = Console.ReadLine()) != "Love!")
            {
                string[] split = jumpCommand.Split();
                int jumpLength = int.Parse(split[1]);

                if (jumpLength + currentLocation >= neighbourhood.Length)
                {
                    currentLocation = 0;
                }
                else
                {
                    currentLocation += jumpLength;
                }
                if (neighbourhood[currentLocation] <= 0)
                {
                    Console.WriteLine($"Place {currentLocation} already had Valentine's day.");
                    continue;
                }

                neighbourhood[currentLocation] -= 2;

                if (neighbourhood[currentLocation] <= 0)
                {
                    Console.WriteLine($"Place {currentLocation} has Valentine's day.");
                    housesOfLove++;
                }

            }
            Console.WriteLine($"Cupid's last position was {currentLocation}.");

            if (neighbourhood.Sum() <= 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighbourhood.Length - housesOfLove} places.");
            }
        }
    }
}
