using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            var students = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var tokens = input.Split(" : ");
                var course = tokens[0];
                var user = tokens[1];

                if (!students.ContainsKey(course))
                {
                    students[course] = new List<string>();
                }
                students[course].Add(user);
            }

            foreach (var kvp in students.OrderByDescending(x=>x.Value.Count))
            {
                var currentUsers = kvp.Value;
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                Console.WriteLine($"-- {string.Join("\n-- ", kvp.Value.OrderBy(x=>x))}");
            }
        }
    }
}
