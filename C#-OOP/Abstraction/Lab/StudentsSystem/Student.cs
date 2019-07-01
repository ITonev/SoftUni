using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsSystem
{
    public class Student
    {
        public double Grade { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }
}
