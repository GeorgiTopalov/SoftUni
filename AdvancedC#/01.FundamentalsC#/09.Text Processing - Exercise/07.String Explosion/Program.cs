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
            string textToBlowUp = Console.ReadLine();

            StringBuilder finalText = new StringBuilder();

            int explosionPower = 0;

            for (int i = 0; i < textToBlowUp.Length; i++)
            {
                char currentChar = textToBlowUp[i];

                if (currentChar == '>')
                {
                   
                    finalText.Append(currentChar);
                    explosionPower+= (int)Char.GetNumericValue(textToBlowUp[i + 1]);
                }
                else
                {
                    if (explosionPower > 0)
                    {
                        explosionPower--;
                    }
                    else 
                    {
                        finalText.Append(currentChar);
                    }
                }
            }

            Console.WriteLine(finalText);
        }
    }
}
