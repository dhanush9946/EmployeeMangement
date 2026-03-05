using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Modules.Auth.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
