using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Dictionary<string, int> dishes = new Dictionary<string, int>();

            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();
                int totalFreshness = currentFreshness * currentIngredient;

                if (totalFreshness == 150)
                {
                    AddToDictionary(dishes, "Dipping sauce");
                }
                else if (totalFreshness == 250)
                {
                    AddToDictionary(dishes, "Green salad");

                }
                else if (totalFreshness == 300)
                {
                    AddToDictionary(dishes, "Chocolate cake");

                }
                else if (totalFreshness == 400)
                {
                    AddToDictionary(dishes, "Lobster");
                }
                else
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }
            if (dishes.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }

        static void AddToDictionary(Dictionary<string, int> dishes, string item)
        {
            if (!dishes.ContainsKey(item))
            {
                dishes.Add(item, 0);
            }
            dishes[item]++;
        }
    }
}
