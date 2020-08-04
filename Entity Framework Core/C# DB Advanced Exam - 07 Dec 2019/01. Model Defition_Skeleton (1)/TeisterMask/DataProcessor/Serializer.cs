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
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDTO
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(t => new ExportTaskDTO
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            var attr = new XmlRootAttribute("Projects");

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var serializer = new XmlSerializer(typeof(ExportProjectDTO[]), attr);

            serializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any())
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new 
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d",CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    }).ToList()
                                        
                })
                .ToList()
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return json;
        }
    }
}