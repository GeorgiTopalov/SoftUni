using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] allWhiteTiles = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            List<int> allGreyTiles = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            Stack<int> whiteTiles = new Stack<int>(allWhiteTiles);
            Queue<int> greyTiles = new Queue<int>(allGreyTiles);

            Dictionary<string, int> locations = new Dictionary<string, int>();

            while (true)
            {
                bool isFitting = false;
                int currentTile = greyTiles.Dequeue();

                int currentWhiteTile = whiteTiles.Pop();

                if (currentTile == currentWhiteTile)
                {
                    int area = currentTile + currentWhiteTile;

                    if (area == 40)
                    {
                        string sink = "Sink";
                        locations = AddToDictionary(locations, sink);

                    }
                    else if (area == 50)
                    {
                        string oven = "Oven";
                        locations = AddToDictionary(locations, oven);
                    }
                    else if (area == 60)
                    {
                        string countertop = "Countertop";
                        locations = AddToDictionary(locations, countertop);

                    }
                    else if (area == 70)
                    {
                        string wall = "Wall";
                        locations = AddToDictionary(locations, wall);

                    }
                    else
                    {
                        string floor = "Floor";
                        locations = AddToDictionary(locations, floor);

                    }
                    isFitting = true;
                }
                else
                {
                    currentWhiteTile /= 2;
                }
                if (!isFitting)
                {
                    whiteTiles.Push(currentWhiteTile);
                    greyTiles.Enqueue(currentTile);
                }

                if (greyTiles.Count == 0 || whiteTiles.Count == 0)
                {
                    break;
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }

        }
        static Dictionary<string, int> AddToDictionary(Dictionary<string, int> locations, string location)
        {
            if (!locations.ContainsKey(location))
            {
                locations.Add(location, 0);
            }
            locations[location] += 1;

            return locations;
        }
    }
}
