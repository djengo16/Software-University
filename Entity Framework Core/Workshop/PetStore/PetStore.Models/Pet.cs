using PetStore.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        public byte Age { get; set; }

        [Required]
        public bool IsSold { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Breed")]
        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

    }
}
