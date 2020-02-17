namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
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
            var serializer = new XmlSerializer(typeof(ProjectImportDto[]), new XmlRootAttribute("Projects"));
            var objects = (ProjectImportDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var tasks = new List<Task>();

            foreach (var x in objects)
            {
                if (IsValid(x))
                {
                    var project = new Project
                    {
                        Name = x.Name,
                        OpenDate = DateTime.ParseExact(x.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = null
                    };

                    if (x.DueDate != "" && x.DueDate != null) project.DueDate = DateTime.ParseExact(x.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);

                    context.Projects.Add(project);
                    var oldCount = tasks.Count;
                    AddProjectTasks(context, project, x.Tasks, tasks, sb);
                    var count = tasks.Count - oldCount;
                    sb.AppendLine(String.Format(SuccessfullyImportedProject, x.Name, count));
                }
                else sb.AppendLine(ErrorMessage);
            }

            //var orderedTask = tasks.Reverse();
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValidDate(Project project, TaskImportDto task)
        {
            if (DateTime.Compare(DateTime.ParseExact(task.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture), project.OpenDate) == 1)
            {
                if (project.DueDate == null || DateTime.Compare(project.DueDate.Value, DateTime.ParseExact(task.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)) == 1) return true;
                else return false;
            }
            else return false;
        }
        private static List<Task> AddProjectTasks(TeisterMaskContext context, Project project, TaskImportDto[] tasksDto, List<Task> tasks, StringBuilder sb)
        {
            var counter = 0;

            foreach (var x in tasksDto)
            {
                if (IsValid(x) && IsValidDate(project, x))
                {
                    var task = new Task
                    {
                        ProjectId = project.Id,
                        Name = x.Name,
                        OpenDate = DateTime.ParseExact(x.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(x.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = (ExecutionType)x.ExecutionType,
                        LabelType = (LabelType)x.LabelType
                    };

                    tasks.Add(task);
                    counter++;
                }
                else sb.AppendLine(ErrorMessage);
            }
            return tasks;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var x in objects)
            {
                if (IsValid(x))
                {
                    var employee = new Employee
                    {
                        Username = x.Username,
                        Email = x.Email,
                        Phone = x.Phone
                    };

                    context.Employees.Add(employee);
                    var tasks = x.Tasks.Distinct();
                    var count = 0;

                    foreach (var y in tasks)
                    {
                        if (context.Tasks.Any(z => z.Id == y))
                        {
                            var emplTask = new EmployeeTask
                            {
                                EmployeeId = employee.Id,
                                TaskId = y
                            };

                            count++;
                            context.EmployeesTasks.Add(emplTask);
                        }
                        else sb.AppendLine(ErrorMessage);

                    }

                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, x.Username, count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}