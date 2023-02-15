using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i <= rows; i++)
            {
                int[] currentRow = new int[i + 1];
                currentRow[0] = 1;
                for (int j = 1; j < i + 1; j++)
                {
                    if (j == 0 || j == i - 1)
                    {
                        currentRow[j] = i;
                    }
                    else
                    {
                        currentRow[j] = 
                    }
                }

            }
        }
    }
}