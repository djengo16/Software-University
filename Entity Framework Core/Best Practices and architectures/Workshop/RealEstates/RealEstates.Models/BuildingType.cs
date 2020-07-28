using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RealEstates.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<RealEstateProperty> Properties { get; set; }

    }
}