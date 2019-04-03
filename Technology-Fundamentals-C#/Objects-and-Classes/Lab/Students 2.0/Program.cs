using System;
using System.Collections.Generic;
using System.Linq;

namespace Students_2._0
{
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentsInformation = new List<Students>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                List<string> tokens = input.Split().ToList();

                if (IsStudentExisting(studentsInformation, tokens[0], tokens[1]))
                {

                    Students student = GetStudentData(studentsInformation, tokens[0], tokens[1]);

                    student.Age = int.Parse(tokens[2]);
                    student.HomeTown = tokens[3];
                }

                else
                {
                    Students student = new Students
                    {
                        FirstName = tokens[0],
                        LastName = tokens[1],
                        Age = int.Parse(tokens[2]),
                        HomeTown = tokens[3]
                    };
                    studentsInformation.Add(student);
                }

            }

            string city = Console.ReadLine();

            foreach (var student in studentsInformation.Where(x => x.HomeTown == city))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

        }

        public static Students GetStudentData(List<Students> studentsInformation, string firstName, string lastName)
        {

            Students existingStudent = null;

            foreach (var student in studentsInformation)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;

        }

        public static bool IsStudentExisting(List<Students> studentsInformation, string firstName, string lastName)
        {

            foreach (var student in studentsInformation)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
