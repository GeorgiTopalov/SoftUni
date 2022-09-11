using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList();

            List<string> validUsers = new List<string>();


            foreach (string username in usernames)
            {
                bool userIsValid = true;

                if (username.Length > 2 && username.Length < 17)
                {

                    foreach (char c in username)
                    {
                        if (!char.IsLetterOrDigit(c) && c != '-' && c != '_')
                        {
                            userIsValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    userIsValid = false;

                }
                if (userIsValid == true)
                {
                    validUsers.Add(username);
                }
            }

            foreach (string user in validUsers)
            {
                Console.WriteLine(user);
            }
        }
    }
}