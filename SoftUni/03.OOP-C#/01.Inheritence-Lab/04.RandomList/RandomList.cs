using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random element = new Random();
        public string RandomString()
        {
            var index = element.Next(0, this.Count);
            var randomElement = this[index];
            this.RemoveAt(index);
            return randomElement.ToString();
        }
    }
}
