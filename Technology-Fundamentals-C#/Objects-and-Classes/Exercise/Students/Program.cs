using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirtName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                Student newStudent = new Student(tokens[0], tokens[1], double.Parse(tokens[2]));
                students.Add(newStudent);
            }

            foreach (var student in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{student.FirtName} {student.LastName}: {student.Grade:f2}");
            }

        }
    }
}
