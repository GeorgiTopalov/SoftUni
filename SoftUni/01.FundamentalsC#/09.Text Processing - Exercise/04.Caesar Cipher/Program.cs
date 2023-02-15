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
            string textToEncrypt = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                encryptedText.Append(Convert.ToChar(textToEncrypt[i]+3));
            }

            Console.Write(encryptedText.ToString());
        }
    }
}