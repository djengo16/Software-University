using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Data
{
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }
        //•	Has a Description – a string with min length 5 (required)
        [Required]
        public string Description { get; set; }
        //•	Has a CreatedOn – a datetime(required)
        public DateTime CreatedOn { get; set; }
        //•	Has a CreatorId – a string
        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        //•	Has Creator – a User object
        public User Creator { get; set; }
        //•	Has RepositoryId – a string
        public string RepositoryId { get; set; }
        //•	Has Repository– a Repository object
        public Repository Repository { get; set; }

    }
}
