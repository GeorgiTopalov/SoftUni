using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string currentBiggest = String.Empty;
            double biggestVolume = 0;
            for (int i = 0; i < lines; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    currentBiggest = model;
                }
            }
            Console.WriteLine(currentBiggest);
        }
    }
}