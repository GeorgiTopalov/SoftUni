using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double[] flourNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Queue<double> water = new Queue<double>(waterNums);
            Stack<double> flour = new Stack<double>(flourNums);

            Dictionary<string, int> bakedStuff = new Dictionary<string, int>();

            while (true)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double waterPercentage = (currentWater * 100) / (currentWater + currentFlour);

                if (waterPercentage == 50)
                {
                    AddToDictionary(bakedStuff, "Croissant");
                }
                else if (waterPercentage == 40)
                {
                    AddToDictionary(bakedStuff, "Muffin");
                }
                else if (waterPercentage == 30)
                {
                    AddToDictionary(bakedStuff, "Baguette");
                }
                else if (waterPercentage == 20)
                {
                    AddToDictionary(bakedStuff, "Bagel");
                }
                else
                {
                    AddToDictionary(bakedStuff, "Croissant");

                    if (currentFlour > currentWater)
                    {
                        flour.Push(currentFlour - currentWater);
                    }
                }

                if (water.Count == 0 || flour.Count == 0)
                {
                    break;
                }
            }

            foreach (var item in bakedStuff.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }

        static void AddToDictionary(Dictionary<string, int> bakedStuff, string item)
        {
            if (!bakedStuff.ContainsKey(item))
            {
                bakedStuff.Add(item, 0);
            }
            bakedStuff[item]++;
        }
    }
}
