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
           string concealedMessage = Console.ReadLine();

            string input = string.Empty;

            StringBuilder revealedMessage = new StringBuilder();
            revealedMessage.Append(concealedMessage);

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] inputArgs = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(inputArgs[1]);
                    revealedMessage.Insert(index, ' ');
                }
                else if (command == "Reverse")
                {
                    string substringToReverse = inputArgs[1];

                    if (revealedMessage.ToString().Contains(substringToReverse))
                    {
                        int index = revealedMessage.ToString().IndexOf(substringToReverse);
                        revealedMessage.Remove(index, substringToReverse.Length);
                        string reversedSubstring = ReverseSubString(substringToReverse);
                        revealedMessage.Append(string.Join("", substringToReverse.Reverse()));
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substringToReplace = inputArgs[1];
                    string replacement = inputArgs[2];

                    if (!revealedMessage.ToString().Contains(substringToReplace))
                    {
                        continue;
                    }
                    revealedMessage.Replace(substringToReplace, replacement);

                }
                Console.WriteLine(revealedMessage);
            }
            Console.WriteLine($"You have a new text message: {revealedMessage}");
        }

        static string ReverseSubString(string substringToReverse)
        {
            char[] charArray = substringToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
