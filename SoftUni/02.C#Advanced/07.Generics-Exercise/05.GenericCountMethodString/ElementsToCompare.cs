namespace Generics
{
    using System;
    using System.Collections.Generic;
    
    public class ElementsToCompare<T>
        where T : IComparable
    {
        public ElementsToCompare()
        {
            this.Elements = new List<T>();
        }
        public List<T> Elements { get; set; }

        public int Count( T elementToCompare)
        {
            int count = 0;

            foreach (var element in Elements)
            {
                if (element.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}