using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            PrintAction(dataType);
        }

        static void PrintAction(string dataType)
        {
            if (dataType == "int")
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(input * 2);
            }
            else if (dataType == "real")
            {
                double input = double.Parse(Console.ReadLine());
                Console.WriteLine($"{input * 1.5:F2}");
            }
            else
            {
                string input = Console.ReadLine();
                Console.WriteLine($"${input}$");
            }
        }
    }
}
