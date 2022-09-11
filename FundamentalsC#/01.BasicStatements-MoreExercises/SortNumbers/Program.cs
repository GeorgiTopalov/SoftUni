using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            List<int> list = new List<int>()
            {
                numberOne,
                numberTwo,
                numberThree
            };

            list.Sort();
            list.Reverse();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }    
        }
    }
}