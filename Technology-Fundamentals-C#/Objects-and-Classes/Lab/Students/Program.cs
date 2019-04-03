using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        class Students
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public string Hometown;

        }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Students> students = new List<Students>();
            while (command != "end")
            {
                string[] token = command.Split();
                Students currentStudent = new Students
                {
                    FirstName = token[0],
                    LastName = token[1],
                    Age = int.Parse(token[2]),
                    Hometown = token[3]
                };

                students.Add(currentStudent);
                command = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (var item in students.Where(x => x.Hometown == city))
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }


        }
    }
}
