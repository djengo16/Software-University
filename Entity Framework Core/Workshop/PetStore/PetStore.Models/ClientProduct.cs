using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetStore.Models
{
    public class ClientProduct
    {
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public Client Client { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
