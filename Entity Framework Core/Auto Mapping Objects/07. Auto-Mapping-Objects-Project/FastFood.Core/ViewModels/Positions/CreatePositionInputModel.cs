using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [Required]
        [MinLength(3)]
        public string PositionName { get; set; }
    }
}
