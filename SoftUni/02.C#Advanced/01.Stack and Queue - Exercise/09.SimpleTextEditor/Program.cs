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
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> text = new Stack<string>();

            Stack<string> undoText = new Stack<string>();
            undoText.Push("");

            for (int i = 0; i < numberOfOperations; i++)
            {
                string input = Console.ReadLine();

                if (input[0] == '4')
                {
                    text.Pop();
                    text.Push(undoText.Pop());

                }
                else
                {
                    string[] inputArgs = input.Split(' ');
                    string command = inputArgs[0];

                    if (command == "1")
                    {
                        if (text.Count > 0)
                        {
                            undoText.Push(text.Pop());
                            text.Push(undoText.Peek() + inputArgs[1]);
                        }
                        else
                        {
                            text.Push(inputArgs[1]);
                        }

                    }
                    else if (command == "2")
                    {
                        int erraserCount = int.Parse(inputArgs[1]);
                        string textToDelete = text.Peek();
                        int startIndex = textToDelete.Length - erraserCount;

                        undoText.Push(text.Peek());

                        string currentText = text.Pop();
                        text.Push(currentText.Remove(startIndex, erraserCount));


                    }
                    else
                    {
                        int indexOfNumber = int.Parse(inputArgs[1]) - 1;
                        string textToLookForChar = text.Peek();

                        for (int k = 0; k < textToLookForChar.Length; k++)
                        {
                            if (k == indexOfNumber)
                            {
                                string currentText = text.Peek();
                                Console.WriteLine(currentText[k]);
                            }

                        }
                    }

                }
            }
        }
    }
}


