using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class WordsToSwap<T>
    {
        public WordsToSwap()
        {
            this.Words = new List<T>();
        }
        public List<T> Words { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var word in Words)
            {
                sb.AppendLine($"{typeof(T)}: {word}");
            }

            return sb.ToString();
        }
        public List<T> Swap(int indexOne, int indexTwo)
        {
            T savedValue = Words[indexOne];
            Words[indexOne] = Words[indexTwo];
            Words[indexTwo] = savedValue;

            return Words;
        }
    }
}
