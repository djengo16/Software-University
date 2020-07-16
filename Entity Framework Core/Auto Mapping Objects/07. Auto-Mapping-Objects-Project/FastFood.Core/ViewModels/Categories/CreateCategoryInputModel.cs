using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        public string CategoryName { get; set; }
    }
}
