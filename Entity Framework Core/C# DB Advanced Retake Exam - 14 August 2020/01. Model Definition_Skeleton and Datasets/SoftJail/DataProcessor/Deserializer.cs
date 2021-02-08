namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentCellDTO[] departmentsDTO = JsonConvert.DeserializeObject<ImportDepartmentCellDTO[]>(jsonString);

            List<Department> validDepartments = new List<Department>();

            foreach (var departmentDTO in departmentsDTO)
            {
                if (!IsValid(departmentDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Department department = new Department
                {
                    Name = departmentDTO.Name
                };

                foreach (var cellDTO in departmentDTO.Cells)
                {
                    if (!IsValid(cellDTO))
                    {
                        //  sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDTO.CellNumber,
                        HasWindow = bool.Parse(cellDTO.HasWindow)
                    });
                }



                if (department.Cells.Count != departmentDTO.Cells.Count)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }


            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerMailDTO[] prisonersDTO = JsonConvert.DeserializeObject<ImportPrisonerMailDTO[]>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDTO in prisonersDTO)
            {
                if (!IsValid(prisonerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime IncarcerationDate;

                bool isIncarcerationDateValid = DateTime
                        .TryParseExact(prisonerDTO.IncarcerationDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out IncarcerationDate);
                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                DateTime? prisonerReleaseDate;
                if (!(string.IsNullOrEmpty(prisonerDTO.ReleaseDate)))
                {
                    DateTime prisonerReleaseDateValue;

                    bool isReleaseDateValid = DateTime
                   .TryParseExact(prisonerDTO.ReleaseDate,
                   "dd/MM/yyyy",
                   CultureInfo.InvariantCulture,
                   DateTimeStyles.None,
                   out prisonerReleaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    prisonerReleaseDate = prisonerReleaseDateValue;
                }
                else
                {
                    prisonerReleaseDate = null;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDTO.FullName,
                    Nickname = prisonerDTO.Nickname,
                    Age = prisonerDTO.Age,
                    IncarcerationDate = IncarcerationDate,
                    ReleaseDate = prisonerReleaseDate,                    
                    CellId = prisonerDTO.CellId
                };
                
                if(prisonerDTO.Bail == null)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }
                

                foreach (var mailDTO in prisonerDTO.Mails)
                {
                    if (!IsValid(mailDTO))
                    {

                        continue;
                    }
                    bool isMailAddressValid = true;

                    foreach (var part in mailDTO.Address)
                    {
                        if (!(char.IsLetterOrDigit(part) || char.IsWhiteSpace(part) || part == '.'))
                        {

                            isMailAddressValid = false;
                            break;
                            // continue;
                        }
                    }

                    if (!mailDTO.Address.EndsWith("str."))
                    {
                        isMailAddressValid = false;
                        break;
                    }

                    if (isMailAddressValid)
                    {
                        prisoner.Mails.Add(new Mail
                        {
                            Description = mailDTO.Description,
                            Sender = mailDTO.Sender,
                            Address = mailDTO.Address
                        });
                    }
                }
                if (prisoner.Mails.Count != prisonerDTO.Mails.Count)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}