using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string pattern = @">>(?<furniture>[A-Z]{1,}|[A-Z][a-z]{1,})<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";

            List<string> boughtFurniture = new List<string>();
            double totalMoneySpent = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    boughtFurniture.Add(match.Groups["furniture"].Value);

                    string price = match.Groups["price"].Value;
                    string quantity = match.Groups["quantity"].Value;
                    double cost = double.Parse(price) * double.Parse(quantity);
                    totalMoneySpent += cost;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (string furniture in boughtFurniture)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalMoneySpent:f2}");
        }
    }
}
