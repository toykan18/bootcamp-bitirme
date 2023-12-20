using System.ComponentModel.DataAnnotations;

namespace BlogApp.ViewModels
{
    public class RegisterViewModels{
        [Required]
        public string UserName { get; set; } = string.Empty;
        
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
       
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "PASSWORDS SHOULD MATCH.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
