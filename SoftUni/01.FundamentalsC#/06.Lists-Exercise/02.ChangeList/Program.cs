using System;
using System.Linq;
using System.Collections.Generic;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                if (command == "end")
                {
                    break;
                }

                else if (tokens[0] == "Delete")
                {
                    int numbersToRemove = int.Parse(tokens[1]);
                    numbers.RemoveAll(numbers => numbers == numbersToRemove);
                }
                else if (tokens[0] == "Insert")
                {
                    int indexToInsert = int.Parse(tokens[2]);
                    int numberToInsert = int.Parse(tokens[1]);
                    numbers.Insert(indexToInsert, numberToInsert);
                }
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
