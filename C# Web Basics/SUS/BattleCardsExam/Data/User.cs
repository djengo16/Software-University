using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCardsExam.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }
        //        •	Has an Id – a string, Primary Key
        public string Id { get; set; }
        //•	Has a Username – a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        //•	Has an Email - a string (required)
        [Required]
        public string Email { get; set; }
        //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        [Required]       
        public string Password { get; set; }
        //•	Has UserCard collection
        public ICollection<UserCard> UserCards { get; set; }

    }
}
