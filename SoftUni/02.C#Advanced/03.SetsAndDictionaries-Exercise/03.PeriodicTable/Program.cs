using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
           int numberOfChemicals = int.Parse(Console.ReadLine());

            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < numberOfChemicals; i++)
            {
                string chemicalCompounds = Console.ReadLine();
                string[] chemicalArgs = chemicalCompounds
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicalArgs.Length; j++)
                {
                    chemicals.Add(chemicalArgs[j]);
                }
            }

            foreach (string chemical in chemicals)
            {
                Console.Write($"{chemical} ");
            }
        }
    }
}