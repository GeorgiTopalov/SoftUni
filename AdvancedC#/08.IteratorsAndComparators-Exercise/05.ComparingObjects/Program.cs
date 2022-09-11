using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = people[n - 1];

            int equalPeople = 0;
            int differentPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    differentPeople++;
                }
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
            }

        }
    }
}