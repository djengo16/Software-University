using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallSeatsDTO
    {
        [JsonProperty("Name")]
        [JsonRequired]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [JsonProperty("Is4Dx")]
        public bool Is4Dx { get; set; }

        [JsonProperty("Is3D")]
        public bool Is3D { get; set; }

        [JsonProperty("Seats")]
        public int Seats { get; set; }
    }
    //"Name": "Methocarbamol",
    //"Is4Dx": false,
    //"Is3D": true,
    //"Seats": 52

}
