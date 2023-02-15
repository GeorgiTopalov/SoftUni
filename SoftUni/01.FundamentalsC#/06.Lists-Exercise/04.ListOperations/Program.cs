using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                
                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }
                else if (command == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                }
                else if (command == "Insert")
                {
                    
                    int indexToInsertTo = int.Parse(tokens[2]);
                    int numberToInsert = int.Parse(tokens[1]);
                    if (indexToInsertTo > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(indexToInsertTo, numberToInsert);
                }
                else if (command == "Remove")
                {
                    int indexToRemoveFrom = int.Parse(tokens[1]);

                    if (indexToRemoveFrom > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(indexToRemoveFrom);
                }
                else if (command == "Shift" && tokens[1] == "left")
                {
                    int timesToShift = int.Parse(tokens[2]);

                    for (int i = 0; i < timesToShift; i++)
                    {
                        int numberToShift = numbers[0];

                        numbers.RemoveAt(0);
                        numbers.Add(numberToShift);
                    }
                }
                else if (command == "Shift" && tokens[1] == "right")
                {
                    int timesToShift = int.Parse(tokens[2]);

                    for (int i = 0; i < timesToShift; i++)
                    {
                        int numberToShift = numbers[numbers.Count - 1];

                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, numberToShift);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
