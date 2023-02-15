using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Plant
    {
        public Plant(string name, string rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = 0.00;
            this.RatingsCount = 0;
        }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public double Rating { get; set; }

        public int RatingsCount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());


            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < numberOfPlants; i++)
            {
                string plant = Console.ReadLine();
                string[] plantArgs = plant
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                Plant newPlant = new Plant(plantArgs[0], plantArgs[1]);
                plants.Add(newPlant);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] inputArgs = input
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string plantName = inputArgs[1];

                if (command == "Rate")
                {
                    double rating = double.Parse(inputArgs[2]);
                    if (plants.Any(plant => plant.Name == plantName))
                    {
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == plantName)
                            {
                                plant.Rating += rating;
                                plant.RatingsCount++;
                            }
                        }
                        continue;
                    }
                }
                else if (command == "Update")
                {
                    string updateRarity = inputArgs[2];

                    if (plants.Any(plant => plant.Name == plantName))
                    {
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == plantName)
                            {
                                plant.Rarity = updateRarity;
                            }
                        }
                        continue;
                    }
                }
                else
                {
                    if (plants.Any(plant => plant.Name == plantName))
                    {
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == plantName)
                            {
                                plant.Rating = 0;
                                plant.RatingsCount = 0;
                            }
                        }
                        continue;
                    }
                }
                Console.WriteLine("error");

            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                double averageRating = plant.Rating / plant.RatingsCount;
                if (plant.Rating == 0)
                {
                    averageRating = 0.00;
                }
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {averageRating:f2}");

            }
        }
    }
}
