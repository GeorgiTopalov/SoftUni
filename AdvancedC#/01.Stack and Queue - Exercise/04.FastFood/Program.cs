using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueOfOrders = new Queue<int>(orders);

            int biggestOrder = 0;

            foreach (int order in orders)
            {
                if (order > biggestOrder)
                {
                    biggestOrder = order;
                }
            }
            Console.WriteLine(biggestOrder);

            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i] <= quantityOfFood)
                {
                    queueOfOrders.Dequeue();
                    quantityOfFood -= orders[i];
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queueOfOrders)}");
                    break;
                }
            }
            if (queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

