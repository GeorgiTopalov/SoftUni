using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Students
    {
        public Students(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
          int studentsCount = int.Parse(Console.ReadLine());

            List<Students> students = new List<Students>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] currentStudent = Console.ReadLine().Split().ToArray();

                Students student = new Students(currentStudent[0], currentStudent[1], double.Parse(currentStudent[2]));

                students.Add(student);
            }

            List<Students> sortedStudents = students.OrderByDescending(students => students.Grade).ToList(); 

            foreach (Students student in sortedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
