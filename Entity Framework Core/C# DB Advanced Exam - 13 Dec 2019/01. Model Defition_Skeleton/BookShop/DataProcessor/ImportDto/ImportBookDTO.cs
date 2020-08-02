using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(1,3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }

        [Range(typeof(decimal),"0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Range(50,5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        [Required]
        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }
    }
  //  <Book>
  //  <Name>Hairy Torchwood</Name>
  //  <Genre>3</Genre>
  //  <Price>41.99</Price>
  //  <Pages>3013</Pages>
  //  <PublishedOn>01/13/2013</PublishedOn>
  //</Book>
//  •	Name - text with length[3, 30]. (required)
//•	Genre - enumeration of type Genre, with possible values(Biography = 1, Business = 2, Science = 3) (required)
//•	Price - decimal in range between 0.01 and max value of the decimal
//•	Pages – integer in range between 50 and 5000
//•	PublishedOn - date and time(required)

}
