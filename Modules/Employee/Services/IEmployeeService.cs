using EmployeeManagementSystem.Modules.Employee.ViewModels;
using EmployeeManagementSystem.Data.Models;

namespace EmployeeManagementSystem.Modules.Employee.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeViewModel model);
        Task<List<Data.Models.Employee>> GetAllEmployeesAsync();
    }
}