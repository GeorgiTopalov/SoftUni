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

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();

            string action = String.Empty;

            while ((action = Console.ReadLine()) != "Print")
            {
                string[] actionArgs = action.Split(';');

                string method = actionArgs[0];
                string operation = actionArgs[1];
                string value = actionArgs[2];

               if (method == "Add filter")
                {
                    allFilters.Add(operation + value, GetPredicate(operation, value));
                }
                else
                {
                    allFilters.Remove(operation + value);
                }
            }

            foreach (var filter in allFilters)
            {
                names.RemoveAll(filter.Value);
            }

            Console.WriteLine(String.Join(' ', names));



        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if (operation == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            if (operation == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            if (operation == "Contains")
            {
                return x => x.Contains(value);
            }

            int valueAsInt = int.Parse(value);

            return x => x.Length == valueAsInt;
        }
    }
}