using System;


namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
         int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            int totalPassengers = 0;
            for (int i = 0; i < n; i++)
            {
              int wagonPassengers = int.Parse(Console.ReadLine());
                array[i] = wagonPassengers;
                totalPassengers += wagonPassengers;
            }

            Console.WriteLine(string.Join (" ", array));
            Console.WriteLine(totalPassengers);
        }
    }
}