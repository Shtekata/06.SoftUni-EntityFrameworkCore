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
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Count > 0)
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Name)
                .Select(x => new ProjectExportDto
                {
                    ProjectName = x.Name,
                    TackCount = x.Tasks.Count,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(y => new TaskExportDto
                    {
                        Name = y.Name,
                        Label = y.LabelType.ToString()
                    })
                    .OrderBy(y => y.Name)
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProjectExportDto[]), new XmlRootAttribute("Projects"));
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty});
            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().Trim();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {

            var employees = context.Employees
            .Where(x => x.EmployeesTasks.Any(y => DateTime.Compare(y.Task.OpenDate, date) == 1))
            .OrderByDescending(x => x.EmployeesTasks.Count(y => DateTime.Compare(y.Task.OpenDate, date) == 1))
            .ThenBy(x => x.Username)
            .Select(x => new EmployeeExportDto
            {
                Username = x.Username,
                Tasks = x.EmployeesTasks
                .Where(y => DateTime.Compare(y.Task.OpenDate, date) == 1)
                .Select(a => new EmployeeTaskstDto
                {
                    TaskName = a.Task.Name,
                    OpenDate = a.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                    DueDate = a.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                    LabelType = a.Task.LabelType.ToString(),
                    ExecutionType = a.Task.ExecutionType.ToString()
                })
                .OrderByDescending(y => DateTime.ParseExact(y.DueDate, "d", CultureInfo.InvariantCulture))
                .ThenBy(y => y.TaskName)
                .ToList()
            })
            .Take(10)
            .ToList();

            var res = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);
            return res;
        }
    }
}