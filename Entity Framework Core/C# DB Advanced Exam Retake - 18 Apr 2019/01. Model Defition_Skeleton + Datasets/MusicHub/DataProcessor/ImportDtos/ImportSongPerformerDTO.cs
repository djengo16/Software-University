using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformerDTO
    {
        //       •	FirstName– text with min length 3 and max length 20 (required) 

        [XmlElement("FirstName")]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        //•	LastName– text with min length 3 and max length 20 (required) 
        [XmlElement("LastName")]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        //•	Age – integer(in range between 18 and 70) (required)

        [XmlElement("Age")]
        [Required]
        [Range(18, 70)]
        public int Age { get; set; }

        //•	NetWorth – decimal (non-negative, minimum value: 0) (required)

        [XmlElement("NetWorth")]
        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportSongIdDTO[] PerformersSongs { get; set; }

    }
    //  <Performer>
    //  <FirstName>Peter</FirstName>
    //  <LastName>Bree</LastName>
    //  <Age>25</Age>
    //  <NetWorth>3243</NetWorth>
    //  <PerformersSongs>
    //    <Song id = "2" />
    //    < Song id="1" />
    //  </PerformersSongs>
    //</Performer>

}
