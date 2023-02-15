using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string URL)
        {
            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Call(string number)
        {

            if (number.Length == 10)
            {
                Console.WriteLine($"Calling... {number}");

            }
            else if (number.Length == 7)
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
