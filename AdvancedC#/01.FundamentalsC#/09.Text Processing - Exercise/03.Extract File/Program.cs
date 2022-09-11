using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = Console.ReadLine();

            string[] directories = fileLocation
                .Split(new char[] { '.', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            string fileExtension = directories[directories.Length - 1];
            string fileName = directories[directories.Length - 2];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}