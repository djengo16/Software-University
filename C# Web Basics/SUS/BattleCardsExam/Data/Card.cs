using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCardsExam.Data
{
    public class Card
    {
        public Card()
        {            
            this.UserCards = new HashSet<UserCard>();
        }
        //        •	Has Id – an int, Primary Key
        public int Id { get; set; }
        //•	Has Name – a string (required); min.length: 5, max.length: 15
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        //•	Has ImageUrl – a string (required)
        [Required]
        public string ImageUrl { get; set; }
        //•	Has Keyword – a string (required)
        [Required]
        public string Keyword { get; set; }
        //•	Has Attack – an int (required); cannot be negative
        [Required]
        public int Attack { get; set; }
        //•	Has Health – an int (required); cannot be negative
        [Required]
        public int Health { get; set; }
        //•	Has a Description – a string with max length 200 (required)
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        //•	Has UserCard collection
        public ICollection<UserCard> UserCards { get; set; }

    }
}
