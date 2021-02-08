using Suls.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Data
{
    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }
        //•	Has a Name – a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        //•	Has Points– an integer between 50 and 300 (required)
        [Required]
        [MaxLength(300)]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }

    }
}
