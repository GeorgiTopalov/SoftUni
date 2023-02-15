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
            string passowrd = Console.ReadLine();

            string input = string.Empty;
            StringBuilder newPassword = new StringBuilder();
            newPassword.Append(passowrd);

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "TakeOdd")
                {
                    string oldPassword = newPassword.ToString();
                    newPassword.Clear();

                    for (int i = 0; i < oldPassword.Length; i++)
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            newPassword.Append(oldPassword[i]);
                        }
                    }
                    Console.WriteLine(newPassword);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(inputArgs[1]);
                    int length = int.Parse(inputArgs[2]);

                    newPassword.Remove(index, length);

                    Console.WriteLine(newPassword);
                }
                else
                {
                    string substring = inputArgs[1];
                    string replacement = inputArgs[2];

                    if (newPassword.ToString().Contains(substring))
                    {
                        newPassword = newPassword.Replace(substring, replacement);
                        Console.WriteLine(newPassword);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {newPassword}");
        }
    }
}
