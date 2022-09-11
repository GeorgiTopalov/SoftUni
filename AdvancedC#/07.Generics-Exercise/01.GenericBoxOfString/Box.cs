using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        List<T> items;
        public Box()
        {
           this.Items = new List<T>();
        }

        public List<T> Items { get; set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }

            return stringBuilder.ToString();
        }
    }

}
