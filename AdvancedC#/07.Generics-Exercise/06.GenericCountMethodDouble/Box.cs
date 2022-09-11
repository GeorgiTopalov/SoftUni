namespace Generics
{
    using System;
    using System.Collections.Generic;
    public class Box<T>
        where T : IComparable

    {
        public List<T> Items { get; set; }
        public Box()
        {
            this.Items = new List<T>();
        }

        public int Count(T element)
        {
            int counter = 0;

            foreach (T item in this.Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}