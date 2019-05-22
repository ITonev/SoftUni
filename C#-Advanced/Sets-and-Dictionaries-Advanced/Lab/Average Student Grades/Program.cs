using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var student = Console.ReadLine().Split();
                var studentName = student[0];
                var grade = double.Parse(student[1]);

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<double>();
                }

                students[studentName].Add(grade);
            }

            foreach (var kvp in students)
            {
                var student = kvp.Key;
                var grades = kvp.Value;

                Console.WriteLine($"{student} -> {string.Join(" ", grades.Select(x => x.ToString("F2")))} (avg: {grades.Average():f2})");
            }
        }
    }
}
