using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ImportEmployeeDTO
    {
        [JsonProperty("Username")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Za-z0-9]+$")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        [Required]
        [RegularExpression(@"(\d{3}-\d{3}-\d{4})")]
        public string Phone { get; set; }
        
        public int[] Tasks { get; set; }

    }
    //"Username": "jstanett0",
    //"Email": "kknapper0@opera.com",
    //"Phone": "819-699-1096",
    //"Tasks": [
    //  34,
    //  32,
    //  65
    //]

}
