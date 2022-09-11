using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToFold = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int foldingNumbers = arrayToFold.Length / 4;

            int[] foldedArrayOne = new int[foldingNumbers];
            int[] foldedArrayTwo = new int[foldingNumbers];
            int[] unfoldedArray = new int[foldingNumbers * 2];

            for (int i = 0; i < foldingNumbers; i++)
            {
                foldedArrayOne[i] = arrayToFold[i];
                foldedArrayTwo[i] = arrayToFold[arrayToFold.Length - 1 - i];
             }

            for (int i = 0;i < unfoldedArray.Length; i++)
            {
                unfoldedArray[i] = arrayToFold[i + foldingNumbers];
            }
            Array.Reverse(foldedArrayOne);

            int[] foldedArray = new int[foldedArrayOne.Length + foldedArrayTwo.Length];
            Array.Copy(foldedArrayOne, foldedArray, foldedArrayOne.Length);
            Array.Copy(foldedArrayTwo, 0, foldedArray, foldedArrayOne.Length, foldedArrayTwo.Length);

            int[] sumArray = new int[foldedArray.Length];

            // make an array for the middle part

            for (int j = 0; j < sumArray.Length; j++)
            {
                sumArray[j] = foldedArray[j] + unfoldedArray[j];
            }

            Console.WriteLine(String.Join(' ', sumArray));
        }
    }
}