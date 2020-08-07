using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMovieDTO
    {
        [JsonProperty("Title")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [JsonProperty("Genre")]
        //[Range(0,9)]
        [Required]
        public string Genre { get; set; }

        [JsonProperty("Duration")]
        [Required]
        public string Duration { get; set; }

        [JsonProperty("Rating")]
        [Required]
        [Range(1,10)]
        public double Rating { get; set; }

        [JsonProperty("Director")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }
    }
//    •	Title – text with length[3, 20] (required)
//•	Genre – enumeration of type Genre, with possible 
//   values(Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)
//•	Duration – TimeSpan(required)
//•	Rating – double in the range[1, 10] (required)
//•	Director – text with length[3, 20] (required)


    //"Title": "Little Big Man",
    //"Genre": "Western",
    //"Duration": "01:58:00",
    //"Rating": 28,
    //"Director": "Duffie Abrahamson"

}
