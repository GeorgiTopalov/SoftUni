using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ElementsToCompare<string> elements = new ElementsToCompare<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                elements.Elements.Add(element);
            }

            string stringToCompare = Console.ReadLine();

            int count =  elements.Count(stringToCompare);

            Console.WriteLine(count);

        }
    }
}
