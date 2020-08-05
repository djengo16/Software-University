using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Hall
    {
        public Hall()
        {
            this.Projections = new HashSet<Projection>();

            this.Seats = new HashSet<Seat>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
//•	Id – integer, Primary Key
//•	Name – text with length[3, 20] (required)
//•	Is4Dx - bool
//•	Is3D - bool
//•	Projections - collection of type Projection
//•	Seats - collection of type Seat

}
