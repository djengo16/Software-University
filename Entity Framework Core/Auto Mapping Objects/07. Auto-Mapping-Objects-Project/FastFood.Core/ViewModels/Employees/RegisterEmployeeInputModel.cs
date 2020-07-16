using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(16,50)]
        public int Age { get; set; }


        public string PositionName { get; set; }

        public string Address { get; set; }
    }
}
