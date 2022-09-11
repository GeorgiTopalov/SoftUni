using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DictionariesOrClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int messageCapacity = int.Parse(Console.ReadLine());
            
            string input = string.Empty;

            Dictionary<string, int> users = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArgs = input
                    .Split('=',StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if (command == "Add")
                {
                    string username = inputArgs[1];
                    int sentMessages = int.Parse(inputArgs[2]);
                    int receivedMessages = int.Parse(inputArgs[3]);
                    int totalMessages = sentMessages + receivedMessages;
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, totalMessages);
                    }
                }
                else if (command == "Message")
                {
                    string senderName = inputArgs[1];
                    string receiverName = inputArgs[2];

                    if (users.ContainsKey(senderName) 
                        && users.ContainsKey(receiverName))
                    {
                        users[senderName]++;
                        users[receiverName]++;


                        if (users[senderName] == messageCapacity)
                        {
                            
                            Console.WriteLine($"{senderName} reached the capacity!");
                            users.Remove(senderName);
                        }
                        if (users[receiverName] == messageCapacity)
                        {
                            Console.WriteLine($"{receiverName} reached the capacity!");
                            users.Remove(receiverName);
                        }
                    }
                }
                else
                {
                   string userToRemove = inputArgs[1];

                    if (userToRemove == "All")
                    {
                        users.Clear();
                    }
                    else
                    {
                        users.Remove(userToRemove);
                    }
                }
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} - {user.Value}");
            }
        }
    }
}
