﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse((Console.ReadLine()));

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }
                numbers[number]++;
            }

            foreach (var number in numbers)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }
        }
    }
}