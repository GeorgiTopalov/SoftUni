using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int randomInt = int.Parse(Console.ReadLine());
                box.Items.Add(randomInt);
            }

            Console.WriteLine(box);
        }
    }
}
