using SoftUni.Data;
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
                System.Console.WriteLine(GetEmployeesFullInformation(db));
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
    }
}
