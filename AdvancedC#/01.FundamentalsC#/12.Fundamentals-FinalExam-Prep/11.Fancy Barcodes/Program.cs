using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex pattern = new Regex (@"@#+[A-Z][A-Za-z\d]{4,}[A-Z]@#+");

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();


                if (pattern.IsMatch(barcode))
                {
                    char[] digits = barcode.Where(c => char.IsDigit(c)).ToArray();

                   
                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {string.Join("", digits)}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
