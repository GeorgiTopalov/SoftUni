namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
           using (StreamReader read = new StreamReader(inputFilePath))
            {
                string textLine = read.ReadLine();
                StringBuilder editedText = new StringBuilder();
                char[] elementsToReplace = new char[] { '-', ',', '.', '!', '?' };

                int lineCounter = 0;

                while (textLine != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        foreach (char element in elementsToReplace)
                        {
                            textLine = textLine.Replace(element, '@');
                        }

                        textLine = String.Join(" ", textLine.Split().Reverse());
                        editedText.AppendLine(textLine);
                    }

                    lineCounter++;
                    textLine = read.ReadLine();
                }

                
                return editedText.ToString().TrimEnd();
            }
        }
        private static string ReverseWords(string replacedSymbols)
        {
            throw new NotImplementedException();
        }

        private static string ReplaceSymbols(string line)
        {
            throw new NotImplementedException();
        }
    }

}
