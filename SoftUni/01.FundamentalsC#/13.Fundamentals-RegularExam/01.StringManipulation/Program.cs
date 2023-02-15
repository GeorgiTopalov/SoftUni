using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Fundamentals___Regular_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            while ((input = Console.ReadLine()) != "Done") 
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "Change")
                {
                    string charToReplace = inputArgs[1];
                    string replacement = inputArgs[2];
                    sb.Replace(charToReplace, replacement);

                    Console.WriteLine(sb);
                }
                else if (command == "Includes")
                {
                    string substring = inputArgs[1];

                    if (sb.ToString().Contains(substring))
                    {
                        Console.WriteLine(true);
                    }
                    else
                    {
                        Console.WriteLine(false);
                    }
                }
                else if (command == "End")
                {
                    string substring = inputArgs[1];
                    int indexToCheck = sb.Length - 1;
                    bool isIncluded = true;
                    for (int i = substring.Length - 1; i >= 0; i--)
                    {
                        if (substring[i] != sb[indexToCheck])
                        {
                            isIncluded = false;
                            break;
                        }
                        indexToCheck--;
                    }
                    Console.WriteLine(isIncluded);

                }
                else if (command == "Uppercase")
                {
                     string upperCaseString = sb.ToString().ToUpper();
                    sb.Clear();
                    sb.Append(upperCaseString);
                    Console.WriteLine(sb);
                }
                else if (command == "FindIndex")
                {
                    char charToFind = char.Parse(inputArgs[1]);

                    for (int i = 0; i < sb.Length; i++)
                    {
                        if (charToFind == sb[i])
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
                else
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int count = int.Parse(inputArgs[2]);
                    string substringToCut = sb.ToString().Substring(startIndex, count);
                    sb.Clear();
                    sb.Append(substringToCut);
                    Console.WriteLine(sb);
                }
            }

        }
    }
}
