using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Person
    {
        public Person(string name, string iD, int age)
        {
            this.Name = name;
            this.ID = iD;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] split = input.Split();
                string name = split[0];
                string iD = split[1];
                int age = int.Parse(split[2]);

                if (GetPerson(people, iD) != null)
                {
                    Person person = GetPerson(people, iD);

                    person.Name = name;
                    person.Age = age;

                }
                else
                {
                    Person person = new Person(name, iD, age);
                    people.Add(person);
                }
            }

            List<Person> peopleOrderedByAge = people.OrderBy(p => p.Age).ToList();

            foreach(Person person in peopleOrderedByAge)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        static Person GetPerson(List<Person> people, string iD)
        {
            Person existingpPerson = null;
            foreach (Person person in people)
            {
                if (person.ID == iD)
                {
                    existingpPerson = person;
                }
            }
            return existingpPerson;
        }
    }
}
