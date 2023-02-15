using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            double sum = 0;
            while (true)
            {
                command = Console.ReadLine();

                if (command == "special" || command == "regular")
                {
                    break;
                }
                else if (double.Parse(command) <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    double prices = double.Parse(command);
                    sum += prices;
                }
            }
            if (sum == 0)
            {
                Console.WriteLine("Invalid order!");
                return;

            }
            PrintFinalMessage(sum, command);
        }
        static void PrintFinalMessage(double sum, string command)
        {
            double totalPrice = 0;
            if (command == "regular")
            {
                totalPrice = sum + sum * 0.2;
            }
            else
            {
                totalPrice = (sum + sum * 0.2) * 0.9;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sum:f2}$");
            Console.WriteLine($"Taxes: {sum * 0.2:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}
