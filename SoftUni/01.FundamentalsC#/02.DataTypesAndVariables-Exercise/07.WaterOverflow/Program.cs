using System;


namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
        int lines = int.Parse(Console.ReadLine());

            int currentLiters = 0;
            for (int i = 0; i < lines; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                currentLiters += liters;

                if (currentLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    currentLiters -= liters;
                }
            }
            Console.WriteLine(currentLiters);
        }
    }
}