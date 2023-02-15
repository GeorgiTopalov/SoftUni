using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public interface IHaveBirthday
    {
        public string Name { get; set; }    
        public string Birthdate { get; set; }
    }
}
