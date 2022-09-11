using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] carbonNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steel = new Queue<int>(steelNumbers);
            Stack<int> carbon = new Stack<int>(carbonNumbers);
            Dictionary<string, int> swords = new Dictionary<string, int>();

            while (true)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int sum = currentSteel + currentCarbon;

                if (sum == 70)
                {
                    AddToDictionary(swords, "Gladius");
                }
                else if (sum == 80)
                {
                    AddToDictionary(swords, "Shamshir");

                }
                else if (sum == 90)
                {
                    AddToDictionary(swords, "Katana");

                }
                else if (sum == 110)
                {
                    AddToDictionary(swords, "Sabre");

                }
                else if (sum == 150)
                {
                    AddToDictionary(swords, "Broadsword");

                }
                else
                {
                    carbon.Push(currentCarbon += 5);
                }

                if (steel.Count == 0 || carbon.Count == 0)
                {
                    break;
                }
            }

            if (swords.Count > 0)
            {
                int swordsCount = 0;
                foreach (var sword in swords)
                {
                    swordsCount += sword.Value;
                }
                Console.WriteLine($"You have forged {swordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}"); 
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var sw in swords.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{sw.Key}: {sw.Value}");
            }


        }

        static void AddToDictionary(Dictionary<string, int> swords, string item)
        {
            if (!swords.ContainsKey(item))
            {
                swords.Add(item, 0);
            }
            swords[item]++;
        }
    }
}
