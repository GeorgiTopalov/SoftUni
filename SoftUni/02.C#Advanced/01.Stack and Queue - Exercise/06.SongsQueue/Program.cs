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
            List<string> songsQueue = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList(); 

            Queue<string> songs = new Queue<string>(songsQueue);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songsQueue.Remove(songs.Dequeue());
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
                else
                {
                    string songToAdd = command.Remove(0, 4);

                    if (!songsQueue.Contains(songToAdd))
                    {
                        songs.Enqueue(songToAdd);
                        songsQueue.Add(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

