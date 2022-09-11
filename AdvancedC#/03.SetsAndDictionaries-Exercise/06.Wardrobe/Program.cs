using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfClothes; i++)
            {
                string clothing = Console.ReadLine();
                string[] clothingArgs = clothing.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = clothingArgs[0];

                string[] clothes = clothingArgs[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 0);
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] search = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string searchColor = search[0];
            string searchClothes = search[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                bool isFound = false;

                if (color.Key == searchColor)
                {
                    isFound = true;
                }

                foreach (var clothing in color.Value)
                {
                    if (clothing.Key == searchClothes && isFound == true)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
            }
        }
    }
}