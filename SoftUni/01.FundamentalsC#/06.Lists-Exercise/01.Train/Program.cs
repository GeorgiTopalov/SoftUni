using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string addPassengers = Console.ReadLine();
                string[] tokens = addPassengers.Split();

                if (addPassengers == "end")
                {
                    break;
                }
                else if (tokens[0] == "Add")
                {
                    wagons.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int newPassengers = int.Parse(addPassengers);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + newPassengers <= capacity)
                        {
                            wagons[i] += newPassengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(' ', wagons));
        }
    }
}
