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
           string randomChars = Console.ReadLine();

            StringBuilder nonRepeatingChars = new StringBuilder();

            for (int i = 1; i < randomChars.Length; i++)
            {
                
                if (randomChars[i] != randomChars[i-1])
                {
                    nonRepeatingChars.Append(randomChars[i-1]);
                }
            }
            nonRepeatingChars.Append(randomChars[randomChars.Length-1]);
            Console.WriteLine(nonRepeatingChars.ToString());
        }
    }
}