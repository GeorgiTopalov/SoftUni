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
          int petrolPumpsCount = int.Parse(Console.ReadLine());

            int currentTank = 0;

            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] newPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(newPump);
                
            }
            int startIndex = 0;

            while (true)
            {
                bool tourIsComplete = true;
                int litresInTank = 0;

                foreach (int[] pump in queue)
                {
                    int petrol = pump[0];
                    int distance = pump[1];
                    litresInTank += petrol;

                    if (litresInTank - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        tourIsComplete = false;
                        break;
                    }

                    litresInTank -= distance;
                }

                if (tourIsComplete == true)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}

