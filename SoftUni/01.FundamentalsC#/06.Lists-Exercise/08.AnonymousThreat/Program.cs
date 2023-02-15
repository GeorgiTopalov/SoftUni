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
            List<string> words = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToArray(); ;
                string cmdType = cmdArgs[0];

                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    Merge(words, startIndex, endIndex);
                }
                else if (cmdType == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitions = int.Parse(cmdArgs[2]);

                    Divide(words, index, partitions);
                }
            }

            Console.WriteLine(String.Join(' ', words));
        }

        static void Merge(List<string> words, int startIndex, int endIndex)
        {
            if (!IsIndexValid(words, startIndex))
            {
                startIndex = 0;
            }
            if (!IsIndexValid(words, endIndex))
            {
                endIndex = words.Count - 1;
            }

            StringBuilder mergedWords = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedWords.Append(words[startIndex]);
                words.RemoveAt(startIndex);
            }

            words.Insert(startIndex, mergedWords.ToString());

        }

        static void Divide(List<string> words, int elementsIndex, int partitions)
        {
            string word = words[elementsIndex];

            if (partitions > elementsIndex)
            {
                return;
            }

            int partitionsLength = word.Length / partitions;
            int partitionsReminder = word.Length % partitions;
            int lastPartitionsLength = partitionsLength + partitionsReminder;

            List<string> dividedWords = new List<string>();
            for (int i = 0; i < partitions; i++)
            {
                char[] currentPartition;

                if (i == partitions - 1)
                {
                    currentPartition = word.Skip(i * partitionsLength).Take(partitionsLength).ToArray();
                }
                else
                {
                    currentPartition = word.Skip(i * partitionsLength).Take(partitionsLength).ToArray();
                }
                dividedWords.Add(new string(currentPartition));
            }

            words.RemoveAt(elementsIndex);
            words.InsertRange(elementsIndex, dividedWords);
        }

        static bool IsIndexValid(List<string> words, int index)
        {
            return index >= 0 && index < words.Count;
        }
    }
}
