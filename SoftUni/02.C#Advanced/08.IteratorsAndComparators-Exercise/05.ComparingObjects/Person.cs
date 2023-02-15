using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
     

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int names = this.Name.CompareTo(other.Name);

            if (names != 0)
            {
                return names;
            }

            int age = this.Age.CompareTo(other.Age);

            if (age != 0)
            {
                return age;
            }

            int town = this.Town.CompareTo(other.Town);
            
            if (town != 0)
            {
                return town;
            }

            return 0;
        }
    }
}
