using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
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
