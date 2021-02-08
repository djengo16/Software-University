using Suls.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }

        //•	Has a Username – a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        //•	Has an Email - a string, which holds only valid email(required)
        public string Email { get; set; }

        //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        [Required]
        public string Password { get; set; }

        public ICollection<Submission> Submissions { get; set; }

    }
}
