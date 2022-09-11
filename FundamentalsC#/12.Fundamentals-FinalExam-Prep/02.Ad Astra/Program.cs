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
            string allFood = Console.ReadLine();

            string pattern = @"(#|\|)(?<itemName>[A-Za-z ]*)\1(?<date>[0-3]?[0-9]/[0-9]?[0-2]/[0-9]{2})\1(?<calories>\d+)\1";

            MatchCollection validFood = Regex.Matches(allFood, pattern);
            int totalCalories = 0;

            foreach (Match match in validFood)
            {
              totalCalories += int.Parse(match.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {totalCalories/2000} days!");

            foreach (Match match in validFood)
            {
                Console.WriteLine($"Item: {match.Groups["itemName"]}, Best before: {match.Groups["date"]}, Nutrition: {match.Groups["calories"]}");
            }
        }
    }
}
