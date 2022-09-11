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
            string bigNumber = Console.ReadLine();
            int singleDigit = int.Parse(Console.ReadLine());

            //not allowed to use BigInteger in this exercise!

            StringBuilder productOfNumbers = new StringBuilder();
            int currentNumToKeep = 0;
            if (bigNumber == "0" || singleDigit == 0)
            {
                Console.WriteLine("0");
                return;
            }
           for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int numberToMultiply = (int)Char.GetNumericValue(bigNumber[i]);
                int multipliedNums = numberToMultiply * singleDigit + currentNumToKeep;
                productOfNumbers.Insert(0, multipliedNums%10);
                currentNumToKeep = multipliedNums/10;
            }
           if(currentNumToKeep > 0)
            {
                productOfNumbers.Insert(0, currentNumToKeep);
            }
            Console.WriteLine(productOfNumbers);
        }
    }
}