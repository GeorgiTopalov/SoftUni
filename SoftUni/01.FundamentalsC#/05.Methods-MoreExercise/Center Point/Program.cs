using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine()); 
            int y2 = int.Parse(Console.ReadLine());

            CloserPoint(x1, y1, x2, y2);
        }

        static void CloserPoint(int x1, int y1, int x2, int y2)
        {
          int pointOne = Math.Abs(x1) + Math.Abs(y1);
          int pointTwo = Math.Abs(x2) + Math.Abs(y2);

            if (pointOne <= pointTwo)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
