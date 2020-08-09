using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDTO
    {
        [JsonProperty("FullName")]
        [RegularExpression(@"^([A-z][a-z]+ [A-z][a-z]+)$")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [JsonProperty("Username")]
        [Required]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Age")]
        [Required]
        [Range(3,103)]
        public int Age { get; set; }

        public ImportCardDTO[] Cards { get; set; }
    }

    public class ImportCardDTO
    {
        [Required]
        [RegularExpression(@"^(\d{4} \d{4} \d{4} \d{4})$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }

    //{
    //  "FullName": "",
    //  "Username": "invalid",
    //  "Email": "invalid@invalid.com",
    //  "Age": 20,
    //  "Cards": [
    //    {
    //      "Number": "1111 1111 1111 1111",
    //      "CVC": "111",
    //      "Type": "Debit"
    //    }
    //  ]

}
