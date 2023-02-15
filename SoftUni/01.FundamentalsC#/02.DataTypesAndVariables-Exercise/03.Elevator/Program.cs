using System;


namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int rounds = people / capacity;

            if (people % capacity !=0)
            {
                rounds += 1;
            }
            Console.WriteLine(rounds);
        }
    }
}