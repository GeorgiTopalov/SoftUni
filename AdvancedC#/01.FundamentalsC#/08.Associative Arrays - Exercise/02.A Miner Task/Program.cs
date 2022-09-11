using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = String.Empty;

            Dictionary<string, int> allRecourses = new Dictionary<string, int>();

            while ((resource = Console.ReadLine()) != "stop")
            {
                string quantity = Console.ReadLine();

                if (allRecourses.ContainsKey(resource))
                {
                    allRecourses[resource] += int.Parse(quantity);
                }
                else
                {
                    allRecourses.Add(resource, int.Parse(quantity));
                }
            }

            foreach (var res in allRecourses)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}
