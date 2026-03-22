using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Modules.Employee.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
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

        //Dropdown data
        public List<SelectListItem> Users { get; set; } = new();
    }
}