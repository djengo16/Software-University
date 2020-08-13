using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongIdDTO
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }

      //<Song id = "2" />
      //< Song id="1" />


}
