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
            string sequence = Console.ReadLine();

            
            Stack<char> leftSide = new Stack<char>();

           foreach (char c in sequence)
            {
                if (c == '{' ||
                    c == '[' ||
                    c == '(')
                {
                    leftSide.Push(c);
                    continue;
                }
                if (leftSide.Count == 0)
                {
                    leftSide.Push('!');
                    break;
                }
                if (c == '}' && leftSide.Peek() == '{')
                {
                    leftSide.Pop();
                }
                else if (c == ']' && leftSide.Peek() == '[')
                {
                    leftSide.Pop();
                }
                else if (c == ')' && leftSide.Peek() == '(')
                {
                    leftSide.Pop();
                }
                else
                {
                    break;
                }
            }
           if (leftSide.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");

            }
        }
    }
}


