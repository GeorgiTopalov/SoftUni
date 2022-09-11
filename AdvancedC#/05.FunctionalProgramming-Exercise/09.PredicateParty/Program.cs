using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string action = String.Empty;

            while ((action = Console.ReadLine()) != "Party!")
            {
                string[] actionArgs = action.Split();

                string method = actionArgs[0];
                string operation = actionArgs[1];
                string value = actionArgs[2];

                if (method == "Double")
                {
                   List<string> doubleNames = names.FindAll(GetPredicate(operation, value));


                    if (!doubleNames.Any())
                    {
                        continue;
                    }
                    int index = names.FindIndex(GetPredicate(operation, value));

                    names.InsertRange(index, doubleNames);

                }
                else
                {
                    names.RemoveAll(GetPredicate(operation, value));
                }
            }

            if (names.Any())
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if(operation == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            if (operation == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            
                int valueAsInt = int.Parse(value);

                return x => x.Length == valueAsInt;
        }
    }
}