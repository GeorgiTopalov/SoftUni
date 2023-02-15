using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int wastedFood = 0;

            while (true)
            {
                int currentGuest = guests.Dequeue();

                while(currentGuest > 0)
                {
                    int currentPlate = plates.Pop();
                    currentGuest -= currentPlate;
                }
                wastedFood += Math.Abs(currentGuest);

                if (guests.Count == 0 || plates.Count == 0)
                {
                    break;
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
