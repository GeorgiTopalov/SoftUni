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

            
            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += array[j];
                }
                for (int k = i + 1; k < array.Length; k++)
                {
                    rightSum += array[k];
                }
                
                if ((leftSum == rightSum) || (array.Length == 1))
                {
                    Console.WriteLine(i);
                    break;
                }
                else if ((rightSum != leftSum) && (i == array.Length -1))
                {
                    Console.WriteLine("no");
                }
                
            }
        }
    }
}