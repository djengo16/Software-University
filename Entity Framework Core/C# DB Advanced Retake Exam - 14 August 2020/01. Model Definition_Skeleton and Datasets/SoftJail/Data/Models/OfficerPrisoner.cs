using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [ForeignKey(nameof(Prisoner))]
        [Required]
        public int PrisonerId { get; set; }

        [Required]
        public Prisoner Prisoner { get; set; }

        [ForeignKey(nameof(Officer))]
        [Required]
        public int OfficerId { get; set; }

        [Required]
        public Officer Officer { get; set; }
    }
//    •	PrisonerId – integer, Primary Key
//•	Prisoner – the officer’s prisoner(required)
//•	OfficerId – integer, Primary Key
//•	Officer – the prisoner’s officer(required)

}
