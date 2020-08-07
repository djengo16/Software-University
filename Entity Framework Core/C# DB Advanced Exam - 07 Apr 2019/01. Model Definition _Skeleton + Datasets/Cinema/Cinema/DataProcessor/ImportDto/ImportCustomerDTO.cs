using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerDTO
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(12,110)]
        public int Age { get; set; }

        [XmlElement("Balance")]
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public ImportTicketDTO[] Tickets { get; set; }
    }
//    •	FirstName – text with length[3, 20] (required)
//•	LastName – text with length[3, 20] (required)
//•	Age – integer in the range[12, 110] (required)
//•	Balance - decimal (non-negative, minimum value: 0.01) (required)


    //<Customer>
    //<FirstName>Randi</FirstName>
    //<LastName>Ferraraccio</LastName>
    //<Age>20</Age>
    //<Balance>59.44</Balance>
    //<Tickets>
    //  <Ticket>
    //    <ProjectionId>1</ProjectionId>
    //    <Price>7</Price>
    //  </Ticket>

}
