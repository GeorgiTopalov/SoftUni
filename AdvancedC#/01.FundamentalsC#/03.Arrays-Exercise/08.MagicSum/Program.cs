using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            int sum = int.Parse(Console.ReadLine());

            int counter = 0;
            int currentI = 0;
            int currentJ = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if ((currentI == array[i] && currentJ == array[j]) || (currentI == array[j] && currentJ == array[i]))
                    {
                        break;
                    }
                    if ((array[i] + array[j]) == sum)
                    {
                        if ((array[i] == array[j]) && (counter == 0))
                        {
                            counter++;
                        }
                        Console.WriteLine($"{array[i]} {array[j]}");
                        
                        if (counter == 1)
                        {
                            currentI = array[i];
                            currentJ = array[j];
                            break;
                        }
                    }
                }
            }

        }
    }
}