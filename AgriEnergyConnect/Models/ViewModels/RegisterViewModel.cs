using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; } = null!;  // Added Name property

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = null!;
    }
}
