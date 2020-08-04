namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ExportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Castle.Core.Internal;
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
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportProjectDTO[]), new XmlRootAttribute("Projects"));

            StringBuilder output = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportProjectDTO[] projectDTOs =
                    (ImportProjectDTO[])serializer.Deserialize(stringReader);

                var projects = new List<Project>();

                foreach (var projectDTO in projectDTOs)
                {
                    if (!IsValid(projectDTO))
                    {
                        output.AppendLine(ErrorMessage);

                        continue;
                    }

                    DateTime projectOpenDate;

                    bool isOpenDateValid = DateTime
                        .TryParseExact(projectDTO.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out projectOpenDate);


                    if (!isOpenDateValid)
                    {
                        output.AppendLine(ErrorMessage);

                        continue;
                    }

                    DateTime? projectDueDate;
                    if (!(projectDTO.DueDate.IsNullOrEmpty()))
                    {
                        DateTime projectDueDateValue;

                        bool isDueDateValid = DateTime
                       .TryParseExact(projectDTO.DueDate,
                       "dd/MM/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out projectDueDateValue);

                        if (!isDueDateValid)
                        {
                            output.AppendLine(ErrorMessage);

                            continue;
                        }

                        projectDueDate = projectDueDateValue;
                    }
                    else
                    {
                        projectDueDate = null;
                    }

                    var tasks = new List<Task>();

                    foreach (var taskDTO in projectDTO.Tasks)
                    {
                        if (!IsValid(taskDTO))
                        {
                            output.AppendLine(ErrorMessage);

                            continue;
                        }

                        if(taskDTO.OpenDate.IsNullOrEmpty() 
                            || taskDTO.DueDate.IsNullOrEmpty())
                        {
                            output.AppendLine(ErrorMessage);
                        }

                        DateTime taskOpenDate;

                        bool isTaskOpenDateValid = DateTime
                            .TryParseExact(taskDTO.OpenDate,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out taskOpenDate);

                        DateTime taskDueDate;

                        bool isTaskDueDateValid = DateTime
                            .TryParseExact(taskDTO.DueDate,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out taskDueDate);

                        if (!(isTaskDueDateValid && isTaskOpenDateValid))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }
                        Task task = new Task
                        {
                            Name = taskDTO.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = (ExecutionType)taskDTO.ExecutionType,
                            LabelType = (LabelType)taskDTO.LabelType
                        };
                        tasks.Add(task);
                        

                    }
                    Project project = new Project
                    {
                        Name = projectDTO.Name,
                        OpenDate = projectOpenDate,
                        DueDate = projectDueDate,
                        Tasks = tasks
                    };

                    output.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                    projects.Add(project);
                }
                context.Projects.AddRange(projects);
                context.SaveChanges();
                
            }
            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDTO[] importEmployees = JsonConvert.DeserializeObject<ImportEmployeeDTO[]>(jsonString);

            List<Employee> validEmployees = new List<Employee>();
           // List<EmployeeTask> validTasks = new List<EmployeeTask>();

            foreach (var employeeDTO in importEmployees)
            {
                if (!IsValid(employeeDTO))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                Employee employee = new Employee
                {
                    Username = employeeDTO.Username,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone
                };

                foreach (var taskId in employeeDTO.Tasks.Distinct())
                {
                    if(!context.Tasks.Any(x => x.Id == taskId))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask
                    {
                        TaskId = taskId,
                        Employee = employee
                    };
                    employee.EmployeesTasks.Add(employeeTask);
                }
                validEmployees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(validEmployees);
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