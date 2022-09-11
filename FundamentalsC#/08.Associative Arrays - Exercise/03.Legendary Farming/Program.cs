using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, int> legendaryMats = new Dictionary<string, int>();
            Dictionary<string, int> junkMats = new Dictionary<string, int>();


            bool isObtained = false;
            string firstMaterialGathered = string.Empty;

            while (isObtained != true)
            {
                List<string> materials = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                materials = materials.ConvertAll(m => m.ToLower());

                for (int i = 0; i < materials.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        string material = materials[i];
                        int currentQuantity = int.Parse(materials[i - 1]);
                        if (material == "motes" || material == "shards" || material == "fragments")
                        {
                            if (!legendaryMats.ContainsKey(material))
                            {
                                legendaryMats.Add(material, currentQuantity);
                            }
                            else
                            {
                                legendaryMats[material] += currentQuantity;

                            }

                            if (legendaryMats[material] >= 250)
                            {
                                firstMaterialGathered = materials[i];
                                legendaryMats[material] -= 250;
                                isObtained = true;
                                break;
                            }
                        }
                        else
                        {
                            if (!junkMats.ContainsKey(materials[i]))
                            {
                                junkMats[materials[i]] = 0;
                            }

                            junkMats[materials[i]] += int.Parse(materials[i - 1]);

                        }
                    }
                    
                }
            }
            PrintWhatIsObtained(firstMaterialGathered);
            PrintLeftOverMaterials(legendaryMats, junkMats);
        }
    
        static void PrintWhatIsObtained(string firstMaterialGathered)
        {
            switch (firstMaterialGathered)
            {
                case "shards":
                    {
                        Console.WriteLine("Shadowmourne obtained!");

                        break;
                    }

                case "motes":
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        break;
                    }
                case "fragments":
                    {
                        Console.WriteLine("Valanyr obtained!");
                        break;
                    }
            }
        }
        static void PrintLeftOverMaterials(Dictionary<string, int> legendaryMats, Dictionary<string, int> junkMats)
        {
            foreach (var mat in legendaryMats)
            {
                Console.WriteLine($"{mat.Key}: {mat.Value}");
            }
            foreach (var mat in junkMats)
            {

                Console.WriteLine($"{mat.Key}: {mat.Value}");
            }
        }
    }
}
