using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProduct>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Town { get; set; }
        [Required]
        public string Adress { get; set; }

        public string Notes { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public Client Client { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        public decimal TotalPrice => this.ClientProducts.Sum(x => x.Product.Price * x.Quantity);

    }
}
