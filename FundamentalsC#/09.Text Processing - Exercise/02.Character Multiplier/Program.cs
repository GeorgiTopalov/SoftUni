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
          string[]  stringsToManipulate = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string shorterString = String.Empty;
            string longerString = String.Empty;

            if (stringsToManipulate[0].Length > stringsToManipulate[1].Length)
            {
                shorterString = stringsToManipulate[1];
                longerString = stringsToManipulate[0];

            }
            else
            {
                shorterString = stringsToManipulate[0];
                longerString = stringsToManipulate[1];

            }

            
            int sum = 0;

            for (int i = 0; i < shorterString.Length; i++)
            {
                sum += shorterString[i] * longerString[i];
            }

            longerString = longerString.Substring(shorterString.Length);

            foreach (char c in longerString)
            {
                sum += c;
            }
            Console.WriteLine(sum);
        }
    }
}