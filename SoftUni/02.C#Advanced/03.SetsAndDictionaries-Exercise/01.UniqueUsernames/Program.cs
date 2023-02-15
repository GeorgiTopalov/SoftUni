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
           int numberOfUsers = int.Parse(Console.ReadLine());

            HashSet<string> users = new HashSet<string>();  

            for (int i = 0; i < numberOfUsers; i++)
            {
                string username = Console.ReadLine();
                users.Add(username);
            }

            foreach(string username in users)
            {
                Console.WriteLine(username);
            }
        }
    }
}