using System;
using System.Collections.Generic;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> doublesToCompare = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                doublesToCompare.Items.Add(number);
            }
            double doubleToCompare = double.Parse(Console.ReadLine());
            int count = doublesToCompare.Count(doubleToCompare);

            Console.WriteLine(count);
        }
    }
}
