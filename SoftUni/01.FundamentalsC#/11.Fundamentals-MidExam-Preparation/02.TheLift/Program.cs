using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] < 4)
                {
                    int peopleToMove = 4 - lift[i];
                    if (peopleWaiting < 0)
                    {
                        peopleWaiting = 0;
                    }
                    if (peopleWaiting < peopleToMove)
                    {
                        lift[i] += peopleWaiting;
                    }
                    else
                    {
                        lift[i] += peopleToMove;
                    }
                    peopleWaiting -= peopleToMove;
                }
            }
            if (lift.Sum() < lift.Length * 4)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(' ', lift));
            }
            else if ((lift.Sum() == lift.Length * 4) && (peopleWaiting == 0))
            {
                Console.WriteLine(String.Join(' ', lift));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(String.Join(' ', lift));
            }
        }
    }
}
