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
            string stops = Console.ReadLine();

            StringBuilder allStops = new StringBuilder();
            allStops.Append(stops);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] inputArgs = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(inputArgs[1]);
                    if (index >=0 && index < allStops.Length)
                    {
                        string newStop = inputArgs[2];
                        allStops.Insert(index, newStop);
                    }
                    
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);

                    if (startIndex >= 0 && endIndex < allStops.Length)
                    {
                        allStops.Remove(startIndex, endIndex-startIndex + 1);
                    }
                }
                else
                {
                    string oldString = inputArgs[1];
                    string newString = inputArgs[2];

                    allStops.Replace(oldString, newString);
                }
                Console.WriteLine(allStops);

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {allStops}");
        }
    }
}
