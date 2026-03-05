using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Modules.Employee.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public int UserId { get; set; }

        [Required]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        public DateOnly DateOfJoining { get; set; }

        public bool IsActive { get; set; }
    }
}