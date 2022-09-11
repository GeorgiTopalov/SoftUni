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
            string message = Console.ReadLine();

            string input = String.Empty;
            StringBuilder decodedMessage = new StringBuilder();
            decodedMessage.Append(message);
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] splitArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = splitArgs[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(splitArgs[1]);
                    decodedMessage.ToString().Substring(0, numberOfLetters);
                    decodedMessage.Append(decodedMessage.ToString().Substring(0, numberOfLetters));
                    decodedMessage.Remove(0, numberOfLetters);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(splitArgs[1]);
                    string value = splitArgs[2];

                    decodedMessage.Insert(index, value);
                }
                else
                {
                    string substrToChange = splitArgs[1];
                    string replacement = splitArgs[2];

                    decodedMessage.Replace(substrToChange, replacement);
                }

            }
            Console.WriteLine($"The decrypted message is: {decodedMessage}");

        }
    }
}
