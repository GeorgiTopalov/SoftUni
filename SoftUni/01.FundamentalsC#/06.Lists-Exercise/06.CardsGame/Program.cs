using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < firstHand.Count; i++)
            {
                int cardToCompareOne = firstHand[i];
                int cardToCompareTwo = secondHand[i];
                if (cardToCompareOne > cardToCompareTwo)
                {
                    firstHand.Add(cardToCompareTwo);
                    firstHand.RemoveAt(i);
                    firstHand.Add(cardToCompareOne);
                    secondHand.RemoveAt(i);
                }
                else if (cardToCompareOne < cardToCompareTwo)
                {
                    secondHand.Add(cardToCompareOne);
                    secondHand.RemoveAt(i);
                    secondHand.Add(cardToCompareTwo);
                    firstHand.RemoveAt(i);
                }
                else
                {
                    firstHand.RemoveAt(i);
                    secondHand.RemoveAt(i);
                }
                i = -1;

                if (firstHand.Count == 0 || secondHand.Count == 0)
                {
                    break;
                }
            }
            int sum = 0;
            if (firstHand.Count > 0)
            {
                sum = firstHand.Sum(x => x);
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                sum = secondHand.Sum(x => x);
                Console.WriteLine($"Second player wins! Sum: {sum}");

            }

        }
    }
}
