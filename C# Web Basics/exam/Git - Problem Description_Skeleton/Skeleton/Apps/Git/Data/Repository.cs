using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Data
{
    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }
        //•	Has a Name – a string with min length 3 and max length 10 (required)
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        //•	Has a CreatedOn – a datetime(required)
        public DateTime CreatedOn { get; set; }
        //•	Has a IsPublic – bool (required)
        public bool IsPublic { get; set; }

        //•	Has a OwnerId – a string
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }

        //•	Has a Owner – a User object
        public User Owner { get; set; }
        //•	Has Commits collection – a Commit type
        public ICollection<Commit> Commits { get; set; }

    }
}
