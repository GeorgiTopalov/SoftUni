namespace Generics
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class NumsToSwap<T>
    {
        public List<T> Numbers { get; set; }

        public NumsToSwap()
        {
            Numbers = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var number in Numbers)
            {
                sb.AppendLine($"{typeof(T)}: {number}");
            }

            return sb.ToString();
        }
        public List<T> Swap(int indexOne, int indexTwo)
        {
            T savedValue = Numbers[indexOne];
            Numbers[indexOne] = Numbers[indexTwo];
            Numbers[indexTwo] = savedValue;

            return Numbers;
        }
    }
}