using EmployeeEntity = EmployeeManagementSystem.Data.Models.Employee;

namespace EmployeeManagementSystem.Modules.Employee.Repository
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(EmployeeEntity employee);
        Task<List<EmployeeEntity>> GetAllEmployeesAsync();
        Task<EmployeeEntity?> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(EmployeeEntity employee);
    }
}