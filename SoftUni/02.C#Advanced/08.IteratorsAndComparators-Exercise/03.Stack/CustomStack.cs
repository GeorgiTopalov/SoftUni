using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {

        private List<T> elements;
        private int index;
        public CustomStack()
        {
            this.elements = new List<T>();
            index = 0;
        }
        public T Push(T element)
        {
            elements.Insert(0, element);
            return element;
        }

        public T Pop()
        {
            if (elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return default;
            }
            T element = elements[0];
            elements.RemoveAt(0);
            return element;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return elements.GetEnumerator();    
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
