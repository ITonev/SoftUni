using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; } = "n/a";
        public int Age { get; set; } = -1;

        public Employee(string name, double salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }
    }
}
