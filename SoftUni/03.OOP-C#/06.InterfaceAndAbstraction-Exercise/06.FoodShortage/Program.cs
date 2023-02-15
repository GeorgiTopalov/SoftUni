using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, Citizen> citizens = new Dictionary<string, Citizen>();
            Dictionary<string, Rebel> rebels = new Dictionary<string, Rebel>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] people = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = people[0];
                int age = int.Parse(people[1]);

                if (people.Length == 4)
                {
                    string ID = people[2];
                    string birthDate = people[3];

                    Citizen citizen = new Citizen (name, age, ID, birthDate);
                    citizens.Add(name, citizen);
                }
                else
                {
                    string group = people[2];
                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(name, rebel);
                }
            }

            string input = string.Empty;

            while((input = Console.ReadLine()) != "End")
            {
                if (citizens.ContainsKey(input))
                {
                    citizens[input].BuyFood();
                }
                else if (rebels.ContainsKey(input))
                {
                    rebels[input].BuyFood();
                }
            }

            int totalFood = citizens.Values.Sum(x => x.Food) + rebels.Values.Sum(x => x.Food);

            Console.WriteLine(totalFood);
        }
    }
}
