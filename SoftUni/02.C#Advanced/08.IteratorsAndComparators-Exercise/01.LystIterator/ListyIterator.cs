﻿using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {

        private readonly List<T> elements;
        private int index;
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }  
            return false;
        }

        public bool HasNext()
        {
            return index < elements.Count - 1;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(elements[index]);
            }
        }
    }
}
