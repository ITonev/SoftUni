using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyEmployees = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var token = input.Split(" -> ");
                var company = token[0];
                var employeeID = token[1];

                if (!companyEmployees.ContainsKey(company))
                {
                    companyEmployees[company] = new List<string>();
                }

                if (!companyEmployees[company].Contains(employeeID))
                {
                    companyEmployees[company].Add(employeeID);
                }
            }

            foreach (var kvp in companyEmployees.OrderBy(x=>x.Key))
            {
                var employees = kvp.Value;
                Console.WriteLine($"{kvp.Key}\n" +
                                  $"-- {string.Join("\n-- ",employees)}");
            }
        }
    }
}
