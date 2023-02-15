using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Fundamentals
{
    class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population; 
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string citiesInput = string.Empty;
            
            List<City> citiesToPlunder = new List<City>();

            while ((citiesInput = Console.ReadLine()) != "Sail")
            {
                string[] citiesInputArgs = citiesInput
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = citiesInputArgs[0];
                int cityPopulation = int.Parse(citiesInputArgs[1]);
                int cityGold = int.Parse(citiesInputArgs[2]);

                City newCity = new City(cityName, cityPopulation, cityGold);

                if (!citiesToPlunder.Any(x => x.Name == cityName))
                {
                    citiesToPlunder.Add(newCity);
                }
                else
                {
                    foreach (City city in citiesToPlunder)
                    {
                        if (city.Name == cityName)
                        {
                            city.Gold += cityGold;
                            city.Population += cityPopulation;
                        }
                    }
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string town = inputArgs[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(inputArgs[2]);
                    int gold = int.Parse(inputArgs[3]);
                    

                    foreach (City city in citiesToPlunder)
                    {
                        if (city.Name == town)
                        {
                            city.Gold -= gold;
                            city.Population -= people;
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        }
                        if (city.Gold <= 0 || city.Population <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            citiesToPlunder.Remove(city);
                            break;
                        }
                        
                    }
                }
                else
                {
                    int gold = int.Parse(inputArgs[2]);
                    
                    if (gold >= 0)
                    {
                        foreach (City city in citiesToPlunder)
                        {
                            if (city.Name.Equals(town))
                            {
                                city.Gold += gold;
                                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city.Gold} gold.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }

            }

            if (citiesToPlunder.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesToPlunder.Count} wealthy settlements to go to:");

                foreach (City city in citiesToPlunder)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}
