using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                Console.WriteLine(GetEmployee147(db));
            }
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
                AddressText = "Vitoshka 15",
                TownId = 4
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

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                             .Any(p => p.Project.StartDate.Year >= 2001
                                    && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();

            foreach (var emp in employees)
            {
                var projects = emp.Projects;

                sb.AppendLine($"{emp.EmployeeName} - Manager: {emp.ManagerName}");

                foreach (var p in projects)
                {
                    var startDate = string.Format("{0:M/d/yyyy h:mm:ss tt}", p.StartDate);

                    var endDate = p.EndDate == null ? "not finished" :
                                  string.Format("{0:M/d/yyyy h:mm:ss tt}", p.EndDate);

                    sb.AppendLine($"--{p.Name} - {startDate} - {endDate}");
                }

            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                            .Addresses
                            .Select(a => new
                            {
                                a.AddressText,
                                townName = a.Town.Name,
                                count = a.Employees.Count
                            })
                            .OrderByDescending(a => a.count)
                            .ThenBy(a => a.townName)
                            .ThenBy(a => a.AddressText)
                            .Take(10)
                            .ToList();

            foreach (var add in addresses)
            {
                sb.AppendLine($"{add.AddressText}, {add.townName} - {add.count} employees");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetEmployee147(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                            .Employees
                            .Where(e => e.EmployeeId == 147)
                            .Select(e => new
                            {
                                name = e.FirstName + " " + e.LastName,
                                e.JobTitle,
                                projects = e.EmployeesProjects
                                            .Select(p => new
                                            {
                                                p.Project.Name
                                            })
                                            .OrderBy(p=>p.Name)
                                            .ToList()
                            })
                            .ToList();

            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.name} - {emp.JobTitle}");

                foreach (var pr in emp.projects)
                {
                    sb.AppendLine(pr.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }


    }
}
