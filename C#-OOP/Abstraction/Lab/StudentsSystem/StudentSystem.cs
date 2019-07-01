using System;
using System.Collections.Generic;

namespace StudentsSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] commandLines = Console.ReadLine().Split();

            var command = commandLines[0];

            if (command == "Create")
            {
                var name = commandLines[1];
                var age = int.Parse(commandLines[2]);
                var grade = double.Parse(commandLines[3]);

                if (!students.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    this.students[name] = student;
                }
            }

            else if (command == "Show")
            {
                var name = commandLines[1];

                if (this.students.ContainsKey(name))
                {
                    var student = this.students[name];
                    string studentInfo = $"{student.Name} is {student.Age} years old.";

                    if (student.Grade >= 5.00)
                    {
                        studentInfo += " Excellent student.";
                    }
                    else if (student.Grade < 5.00 && student.Grade >= 3.50)
                    {
                        studentInfo += " Average student.";
                    }
                    else
                    {
                        studentInfo += " Very nice person.";
                    }

                    Console.WriteLine(studentInfo);
                }
            }

            else if (command == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}