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
            string activationKey = Console.ReadLine();

            string input = string.Empty;

            StringBuilder finalKey = new StringBuilder();
            finalKey.Append(activationKey);

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] inputArgs = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "Contains")
                {
                    string substring = inputArgs[1];

                    if (finalKey.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{finalKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string upperOrLower = inputArgs[1];
                    int startIndex = int.Parse(inputArgs[2]);
                    int endIndex = int.Parse(inputArgs[3]);

                    string substringToEdit = finalKey.ToString().Substring(startIndex, endIndex - startIndex);
                    if (upperOrLower == "Upper")
                    {
                        substringToEdit = substringToEdit.ToUpper();
                    }
                    else
                    {
                        substringToEdit = substringToEdit.ToLower();

                    }
                    finalKey.Remove(startIndex, endIndex - startIndex);
                    finalKey.Insert(startIndex, substringToEdit);

                    Console.WriteLine(finalKey);
                }
                else
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);

                    finalKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(finalKey);
                }
            }

            Console.WriteLine($"Your activation key is: {finalKey}");
        }
    }
}
