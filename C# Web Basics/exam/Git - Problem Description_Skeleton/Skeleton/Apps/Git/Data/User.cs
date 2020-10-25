using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }
        //•	Has a Username – a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        //•	Has an Email - a string (required)
        public string Email { get; set; }

        //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        [Required]
        public string Password { get; set; }

        //•	Has Repositories collection – a Repository type
        public ICollection<Repository> Repositories { get; set; }

        //•	Has Commits collection – a Commit type

        public ICollection<Commit> Commits { get; set; }

    }
}
