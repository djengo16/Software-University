using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(decimal),"0.00","1000.00")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
