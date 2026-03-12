using EmployeeManagementSystem.Data.Models;
using EmployeeEntity = EmployeeManagementSystem.Data.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Modules.Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeAsync(EmployeeEntity employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<EmployeeEntity?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                       .Include(e => e.User)
                       .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateEmployeeAsync(EmployeeEntity employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

    }
}