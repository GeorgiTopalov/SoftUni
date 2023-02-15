namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter outputText = new StreamWriter(outputFilePath))
            {
                using (StreamReader inputText = new StreamReader(inputFilePath))
                {
                    string line = string.Empty;
                    int lineNumber = 1;
                    while ((line = inputText.ReadLine()) != null)
                    {
                        int lettersCount = 0;
                        int punctuationCount = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                lettersCount++;
                            }
                            else if (char.IsPunctuation(line[i]))
                            {
                                punctuationCount++;
                            }
                        }

                        line = line + $"({lettersCount}) ({punctuationCount})";

                        outputText.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                    }
                }
            }
        }
    }
}
