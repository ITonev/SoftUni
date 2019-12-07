namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Text;
    using TeisterMask.Data.Models.Enums;
    using System.Globalization;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectsDTO>), new XmlRootAttribute("Projects"));
            var projectsDTO = (List<ImportProjectsDTO>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();

            var sb = new StringBuilder();

            foreach (var dto in projectsDTO)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }

                else
                {
                    var project = new Project
                    {
                        Name = dto.Name,
                        OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    };

                    if (dto.DueDate == null || dto.DueDate == "")
                    {
                    }

                    else
                    {
                        project.DueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    foreach (var task in dto.Tasks)
                    {
                        if (!IsValid(dto.Tasks))
                        {
                            sb.AppendLine(ErrorMessage);
                        }

                        else
                        {
                            //var executionTypes = string.Empty;
                            var exc = Enum.TryParse(task.ExecutionType, out ExecutionType executionTypes);
                            var label = Enum.TryParse(task.LabelType, out LabelType labelexec);

                            var tasks = new Task
                            {
                                Name = task.Name,
                                OpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                DueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                ExecutionType = executionTypes,
                                LabelType = labelexec,
                            };

                            if (tasks.OpenDate < project.OpenDate || tasks.DueDate > project.DueDate)
                            {
                                sb.AppendLine(ErrorMessage);
                            }

                            else
                            {
                                context.Tasks.Add(tasks);
                                project.Tasks.Add(tasks);
                            }
                        }
                    }

                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                    projects.Add(project);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
            //return "";
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDTO = JsonConvert.DeserializeObject<List<ImportEmployeesDTO>>(jsonString);

            var employees = new List<Employee>();
            var sb = new StringBuilder();

            //var emps = new List<EmployeeTask>();

            foreach (var dto in employeesDTO)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                }

                else
                {
                    var employee = new Employee
                    {
                        Username = dto.Username,
                        Email = dto.Username,
                        Phone = dto.Phone
                    };

                    foreach (var taskId in dto.Tasks)
                    {
                        if (context.Tasks.Any(a => a.Id == taskId))
                        {
                            var employeeTask = new EmployeeTask
                            {
                                EmployeeId = employee.Id,
                                TaskId = taskId
                            };


                            //context.EmployeesTasks.Add(employeeTask);
                            employee.EmployeesTasks.Add(employeeTask);
                        }

                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    employees.Add(employee);
                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
                }
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}