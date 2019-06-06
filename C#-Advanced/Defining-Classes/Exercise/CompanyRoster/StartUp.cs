using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine().Split();
                var name = current[0];
                var salary = double.Parse(current[1]);
                var position = current[2];
                var department = current[3];

                Employee employee = new Employee(name, salary, position, department);

                if (current.Length == 5)
                {
                    if (current[4].Contains("@"))
                    {
                        employee.Email = current[4];
                    }

                    else
                    {
                        employee.Age = int.Parse(current[4]);
                    }
                }

                else if (current.Length == 6)
                {
                    employee.Email = current[4];
                    employee.Age = int.Parse(current[5]);
                }

                employees.Add(employee);
            }

            var highestPaidDepartment = employees
                .GroupBy(x => x.Department)
                .OrderByDescending(x=>x.Select(y=>y.Salary).Average())
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Key}");

            foreach (var employee in highestPaidDepartment.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
