using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();
            ListyIterator<string> listyIterator =
                new ListyIterator<string>(elements);

            string command = string.Empty;

            try
            {
                while ((command = Console.ReadLine()) != "END")
                {
                    if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            } 

        }
    }
}
