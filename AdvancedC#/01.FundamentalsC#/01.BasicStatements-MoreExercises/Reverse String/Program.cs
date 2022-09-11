using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            StringBuilder reversedString = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedString.Append(input[i]);
            }

            Console.WriteLine(reversedString);
        }
    }
}