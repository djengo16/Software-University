﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(110)]
        public int Age { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

// •	Id – integer, Primary Key
//•	FirstName – text with length[3, 20] (required)
//•	LastName – text with length[3, 20] (required)
//•	Age – integer in the range[12, 110] (required)
//•	Balance - decimal (non-negative, minimum value: 0.01) (required)
//•	Tickets - collection of type Ticket

}
