using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class ImportTaskDTO
    {
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0,3)]
        [Required]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0,4)]
        [Required]
        public int LabelType { get; set; }
    }
    //    <Name>Australian</Name>
    //    <OpenDate>19/08/2018</OpenDate>
    //    <DueDate>13/07/2019</DueDate>
    //    <ExecutionType>2</ExecutionType>
    //    <LabelType>0</LabelType>
}
