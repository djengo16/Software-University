using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Hall))]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
//    •	Id – integer, Primary Key
//•	HallId – integer, foreign key(required)
//•	Hall – the seat’s hall

}
