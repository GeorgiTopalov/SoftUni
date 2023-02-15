using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());


            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                string query = Console.ReadLine();

                if (query[0] == '1')
                {
                    string[] queryArgs = query
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int numberToPush = int.Parse(queryArgs[1]);

                    numbers.Push(numberToPush);
                }
                else if (query[0] == '2')
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (numbers.Count == 0)
                {
                    continue;
                }
                else if (query[0] == '3')
                {
                    int maxElement = int.MinValue;
                    foreach (int number in numbers)
                    {
                        if (maxElement < number)
                        {
                            maxElement = number;
                        }
                    }
                    Console.WriteLine(maxElement);
                }
                else
                {
                    int minimumElement = int.MaxValue;
                    foreach (int number in numbers)
                    {
                        if (number < minimumElement)
                        {
                            minimumElement = number;
                        }
                    }
                    Console.WriteLine(minimumElement);
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

