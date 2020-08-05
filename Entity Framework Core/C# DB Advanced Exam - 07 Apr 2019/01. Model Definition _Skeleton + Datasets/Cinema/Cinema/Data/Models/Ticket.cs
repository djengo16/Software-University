using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Projection))]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
//    •	Id – integer, Primary Key
//•	Price – decimal (non-negative, minimum value: 0.01) (required)
//•	CustomerId – integer, foreign key(required)
//•	Customer – the customer’s ticket
//•	ProjectionId – integer, foreign key(required)
//•	Projection – the projection’s ticket

}
