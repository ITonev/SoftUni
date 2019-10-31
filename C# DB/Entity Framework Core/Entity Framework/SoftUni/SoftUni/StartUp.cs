using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                            .Employees
                            .Select(t => new
                            {
                                t.EmployeeId,
                                t.FirstName,
                                t.LastName,
                                t.MiddleName,
                                t.JobTitle,
                                t.Salary
                            })
                            .OrderBy(t => t.EmployeeId)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                            .Employees
                            .Select(t => new
                            {
                                t.FirstName,
                                t.Salary
                            })
                            .Where(t => t.Salary > 50000)
                            .OrderBy(t => t.FirstName)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                            .Employees
                            .Select(t => new
                            {
                                t.FirstName,
                                t.LastName,
                                DepartmentName = t.Department.Name,
                                t.Salary
                            })
                            .Where(t => t.DepartmentName == "Research and Development")
                            .OrderBy(t => t.Salary)
                            .ThenByDescending(t => t.FirstName)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            var newAddress = new Address() 
            {
                AddressText="Vitoshka 15",
                TownId=4
            };

            var employeeNakow = context
                                .Employees
                                .FirstOrDefault(t => t.LastName == "Nakov");

            employeeNakow.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                            .Employees
                            .OrderByDescending(a => a.AddressId)
                            .Select(t => new 
                            { 
                                t.Address.AddressText 
                            })
                            .Take(10)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var adr in addresses)
            {
                sb.AppendLine($"{adr.AddressText}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
