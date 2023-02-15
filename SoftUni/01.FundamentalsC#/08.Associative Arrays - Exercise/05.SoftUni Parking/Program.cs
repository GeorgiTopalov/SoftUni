using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Dictionary<string, string> users = new Dictionary<string, string>(); 

            for (int i = 0; i < commandsCount; i++)
            {
                string input = Console.ReadLine();
                string[] split = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = split[0];
                string username = split[1];

                if (command == "register")
                {
                    string licensePlateNumber = split[2];

                    if (!users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        users.Add(username, licensePlateNumber);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                    }
                }
                else
                {
                    if (!users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        users.Remove(username);
                    }
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
