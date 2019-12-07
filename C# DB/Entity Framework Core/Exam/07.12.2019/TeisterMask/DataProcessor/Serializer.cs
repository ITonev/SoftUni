namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(a => a.Tasks.Count >= 1)
                .Select(e => new ExportProjectDTO
                {
                    ProjectName = e.Name,
                    TasksCount = e.Tasks.Count,
                    HasEndDate = e.DueDate != null ? "Yes" : "No",
                    Tasks = e.Tasks
                            .Select(a => new ExportTaskDTO
                            {
                                Name = a.Name,
                                Label = a.LabelType.ToString()
                            })
                            .OrderBy(d=>d.Name)
                            .ToList()
                })
                .OrderByDescending(a=>a.TasksCount)
                .ThenBy(a=>a.ProjectName)
                .ToList();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDTO[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
               .Employees.Where(a => a.EmployeesTasks.Any(c => c.Task.OpenDate >= date))
               .Select(e => new
               {
                   Username = e.Username,
                   Tasks = e.EmployeesTasks
                        .Where(a => a.Task.OpenDate >= date)
                        .OrderByDescending(a => a.Task.DueDate)
                        .ThenBy(a => a.Task.Name)
                        .Select(c => new
                        {
                            TaskName = c.Task.Name,
                            OpenDate = c.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = c.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = c.Task.LabelType.ToString(),
                            ExecutionType = c.Task.ExecutionType.ToString()
                        })
               })
               .OrderByDescending(a => a.Tasks.Count())
               .ThenBy(a => a.Username)
               .Take(10);

            var jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonString.TrimEnd();
        }
    }
}