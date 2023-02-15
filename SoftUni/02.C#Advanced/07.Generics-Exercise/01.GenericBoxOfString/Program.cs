﻿using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string randomString = Console.ReadLine();
                box.Items.Add(randomString);
            }
            Console.WriteLine(box);

        }
    }
}
