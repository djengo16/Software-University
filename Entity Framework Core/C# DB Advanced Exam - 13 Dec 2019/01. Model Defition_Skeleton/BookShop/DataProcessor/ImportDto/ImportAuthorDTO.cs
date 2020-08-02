using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})\-(\d{3})\-(\d{4})$")]
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        
        public BookDTO[] Books { get; set; }
    }

    public class BookDTO
    {
        [JsonProperty("Id")]
        public int? Id { get; set; }
    }
    //  {
    //  "FirstName": "K",
    //  "LastName": "Tribbeck",
    //  "Phone": "808-944-5051",
    //  "Email": "btribbeck0@last.fm",
    //  "Books": [
    //    {
    //      "Id": 79
    //    },
    //    {
    //      "Id": 40
    //    }
    //  ]
    //},

}
