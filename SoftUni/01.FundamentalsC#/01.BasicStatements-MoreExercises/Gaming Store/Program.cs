using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
         decimal startingMoney = decimal.Parse(Console.ReadLine());

            string command;
            decimal balance= startingMoney;

            while ((command = Console.ReadLine()) != "Game Time")
            {
                decimal currentBalance = balance;

                if (command == "OutFall 4")
                {
                    balance -= 39.99M; 
                }
                else if (command == "CS: OG")
                {
                    balance -= 15.99M;
                }
                else if (command == "Zplinter Zell")
                {
                    balance -= 19.99M;
                }
                else if (command == "Honored 2")
                {
                    balance -= 59.99M;
                }
                else if (command == "RoverWatch")
                {
                    balance -= 29.99M;
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    balance -= 39.99M;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }

                if (balance < 0)
                {
                    Console.WriteLine("Too Expensive");
                    balance = currentBalance;
                }
                else
                {
                    Console.WriteLine($"Bought {command}");
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }
            Console.WriteLine($"Total spent: ${startingMoney - balance:F2}. Remaining: ${balance:F2}");
        }
    }
}