using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = String.Empty;
            int targetsShot = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int shotTarget = int.Parse(input);
                if (shotTarget >= targets.Length || shotTarget < 0)
                {
                    continue;
                }
                if (targets[shotTarget] != -1)
                {
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (i == shotTarget)
                        {
                            continue;
                        }
                        else if ((targets[i] > targets[shotTarget]) && (targets[i] != -1))
                        {
                            targets[i] -= targets[shotTarget];
                        }
                        else if ((targets[i] <= targets[shotTarget]) && (targets[i] != -1))
                        {
                            targets[i] += targets[shotTarget];
                        }
                    }
                    targets[shotTarget] = -1;
                    targetsShot++;
                }
            }

            Console.Write($"Shot targets: {targetsShot} -> ");
            Console.Write(String.Join(" ", targets));
        }
    }
}
