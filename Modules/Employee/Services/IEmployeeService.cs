using EmployeeManagementSystem.Modules.Employee.ViewModels;
using EmployeeManagementSystem.Data.Models;

namespace EmployeeManagementSystem.Modules.Employee.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeViewModel model);
        Task<List<Data.Models.Employee>> GetAllEmployeesAsync();
        Task<Data.Models.Employee?> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(Data.Models.Employee employee);
        Task DeleteEmployeeAsync(int id);


        Task<List<User>> GetAllUsersAsync();
    }
}