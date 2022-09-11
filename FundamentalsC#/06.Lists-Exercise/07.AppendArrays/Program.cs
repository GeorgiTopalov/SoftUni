using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> startingList = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            List<int> finalList = new List<int>();

            foreach (string number in startingList)
            {
                finalList.AddRange(number.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            }


            Console.WriteLine(String.Join(' ', finalList));
        }
    }
}
