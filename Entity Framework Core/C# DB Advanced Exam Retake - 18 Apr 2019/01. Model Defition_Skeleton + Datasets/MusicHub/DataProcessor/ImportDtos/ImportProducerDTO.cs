using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^(\+\d{3} \d{3} \d{3} \d{3})$")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDTO[] Albums { get; set; }
    }
    //Name": "Invalid",
    //"Pseudonym": "Rog Coiley",
    //"PhoneNumber": "(105) 9339880",
    //"Albums": 

}
