using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNumber = int.Parse(Console.ReadLine());

            List<string> allGuests = new List<string>();

            for (int i = 0; i < guestsNumber; i++)
            {
                string guestList = Console.ReadLine();
                string[] tokens = guestList.Split();
                string name = tokens[0];
                string goingOrNot = tokens[2];

                if (allGuests.Contains(name))
                {
                    if (goingOrNot == "going!")
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        allGuests.Remove(name);
                    }
                }
                else
                {
                    if (goingOrNot == "going!")
                    {
                    allGuests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                
            }
            for (int i = 0;i < allGuests.Count; i++)
            {
                Console.WriteLine(allGuests[i]);
            }
        }
    }
}
