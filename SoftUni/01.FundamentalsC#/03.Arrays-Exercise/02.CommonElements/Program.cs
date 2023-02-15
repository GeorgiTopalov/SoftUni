using System;
using System.Linq; 

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split(' ');
            string[] inputTwo = Console.ReadLine().Split(' ');

            
            for (int i = 0; i < inputTwo.Length; i++)
            {
                for (int j = 0; j < inputOne.Length; j++)
                {
                    if (inputOne[j] == inputTwo[i])
                    {
                        Console.Write($"{inputOne[j]} ");
                    }
                }
            }
        }
    }
}