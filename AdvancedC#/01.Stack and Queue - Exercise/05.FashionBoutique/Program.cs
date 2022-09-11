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
            int[] clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int currentRack = 0;

            Stack<int> clothesToHang = new Stack<int>(clothes);
            
            for (int i = 0; i < clothes.Length; i++)
            {
                int currentClothing = clothesToHang.Pop();
                currentRack += currentClothing;

                if (currentRack == rackCapacity)
                {
                    currentRack = 0;
                    if (clothesToHang.Count > 0)
                    {
                        racks++;
                    }
                }
                else if (currentRack > rackCapacity)
                {
                    currentRack = currentClothing;
                    racks++;
                }
                
            }
            Console.WriteLine(racks);
        }
    }
}

