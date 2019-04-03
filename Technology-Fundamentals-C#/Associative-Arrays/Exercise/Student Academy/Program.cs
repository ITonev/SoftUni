using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }
                studentsGrades[name].Add(grade);
            }

            foreach (var kvp in studentsGrades.OrderByDescending(x=>x.Value.Average()).Where(x=>x.Value.Average()>=4.50))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():F2}");
            }

        }
    }
}
