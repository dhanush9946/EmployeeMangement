using EmployeeManagementSystem.Data.Models;

namespace EmployeeManagementSystem.Modules.Auth.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
