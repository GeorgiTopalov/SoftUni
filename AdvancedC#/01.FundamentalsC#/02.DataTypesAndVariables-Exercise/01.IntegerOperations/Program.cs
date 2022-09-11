using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
           int number = int.Parse(Console.ReadLine());

            int leftOver = number;
            int digitSum = 0;
            while (leftOver != 0)
            {
                digitSum += leftOver % 10;
                leftOver /= 10;
            }
            Console.WriteLine(digitSum);
        }
    }
}