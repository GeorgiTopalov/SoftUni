using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] outputArray = new int[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string toEncrypt = Console.ReadLine();
                int[] codeArray = new int[toEncrypt.Length];

                for (int j = 0; j <= toEncrypt.Length - 1; j++)
                {
                    if (toEncrypt[j] == 'a' || toEncrypt[j] == 'e' || toEncrypt[j] == 'o' || toEncrypt[j] == 'u' || toEncrypt[j] == 'i')
                    {
                        int codeNumber = Convert.ToInt32(toEncrypt[j] * toEncrypt.Length);
                        codeArray[j] = codeNumber;
                    }
                    else
                    {
                        int codeNumber = Convert.ToInt32(toEncrypt[j] / toEncrypt.Length);
                        codeArray[j] = codeNumber;
                    }
                }
                int sum = codeArray.Sum();
                outputArray[i] = sum;
            }
            Array.Sort(outputArray);
            for (int i = 0;i < numberOfStrings; i++)
            {
                Console.WriteLine(outputArray[i]);
            }
        }
    }
}