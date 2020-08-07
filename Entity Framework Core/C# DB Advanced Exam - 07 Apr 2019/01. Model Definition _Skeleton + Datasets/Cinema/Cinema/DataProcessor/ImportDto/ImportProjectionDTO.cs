using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ImportProjectionDTO
    {
        [XmlElement("MovieId")]
        [Required]
        public int MovieId { get; set; }

        [XmlElement("HallId")]
        [Required]
        public int HallId { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }
    }
//    •	MovieId – integer, foreign key(required)
//•	Movie – the projection’s movie
//•	HallId – integer, foreign key(required)
//•	Hall – the projection’s hall
//•	DateTime - DateTime(required)

  //  <Projection>
  //  <MovieId>38</MovieId>
  //  <HallId>4</HallId>
  //  <DateTime>2019-04-27 13:33:20</DateTime>
  //</Projection>

}
