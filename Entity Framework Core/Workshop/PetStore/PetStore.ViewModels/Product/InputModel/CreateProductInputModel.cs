
using System.ComponentModel.DataAnnotations;

namespace PetStore.ViewModels.Product.InputModel
{
    public class CreateProductInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public int ProductType { get; set; }
    }
}
