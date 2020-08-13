using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongDTO
    {
        //        •	Name – text with min length 3 and max length 20 (required)

        [XmlElement("Name")]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        //•	Duration – TimeSpan(required)
        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }


        //•	CreatedOn – Date(required)
        [XmlElement("CreatedOn")]
        [Required]
        public string CreatedOn { get; set; }

        //•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        //•	AlbumId– integer foreign key
        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }
        //•	WriterId - integer, foreign key(required)

        [XmlElement("WriterId")]
        [Required]
        public int WriterId { get; set; }

        //•	Price – decimal (non-negative, minimum value: 0) (required)

        [XmlElement("Price")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

    }
    //  <Song>
    //  <Name>What Goes Around</Name>
    //  <Duration>00:03:23</Duration>
    //  <CreatedOn>21/12/2018</CreatedOn>
    //  <Genre>Blues</Genre>
    //  <AlbumId>2</AlbumId>
    //  <WriterId>2</WriterId>
    //  <Price>12</Price>
    //</Song>

}
