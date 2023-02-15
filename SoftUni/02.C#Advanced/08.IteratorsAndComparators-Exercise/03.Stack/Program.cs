using IteratorsAndComparators;
using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            CustomStack<int> elements = new CustomStack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.
                    Split(new string[] { " ", ", " },
                    StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                if (command == "Push")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        elements.Push(int.Parse(commandArgs[i]));
                    }
                }
                else
                {
                    elements.Pop();
                }
            }

            foreach (int element in elements)
            {
                Console.WriteLine(element);
            }
            foreach (int element in elements)
            {
                Console.WriteLine(element);
            }
        }
    }
}
