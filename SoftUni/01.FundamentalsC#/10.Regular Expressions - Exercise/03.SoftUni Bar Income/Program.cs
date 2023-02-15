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
            string pattern = @"\%(?<name>[A-Z]{1}[a-z]+)\%[^%$|.]*?\<(?<product>\w+)\>[^%@|.]*?\|(?<quantity>\d+)\|[^%@|.]*?(?<price>\d+(\.\d+)?)\$";

            string command = string.Empty;
            double totalMoney = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    
                    double cost = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {cost:f2}");

                    totalMoney += cost;
                }
            }

            Console.WriteLine($"Total income: {totalMoney:f2}");
        }
    }
}
