using EmployeeManagementSystem.Data.Models;
using EmployeeManagementSystem.Modules.Auth.Repositories;
using EmployeeManagementSystem.Modules.Employee.Repository;
using EmployeeManagementSystem.Modules.Employee.ViewModels;
using EmployeeEntity = EmployeeManagementSystem.Data.Models.Employee;

namespace EmployeeManagementSystem.Modules.Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository userRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               IUserRepository _userRepository
            )
        {
            _employeeRepository = employeeRepository;
            userRepository = _userRepository;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeViewModel model)
        {
            var employee = new EmployeeEntity
            {
                UserId = model.UserId,
                EmployeeCode = model.EmployeeCode,
                Department = model.Department,
                Designation = model.Designation,
                Phone = model.Phone,
                Salary = model.Salary,
                DateOfJoining = model.DateOfJoining,
                IsActive = true
            };

            await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Data.Models.Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task UpdateEmployeeAsync(Data.Models.Employee employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }
    }
}