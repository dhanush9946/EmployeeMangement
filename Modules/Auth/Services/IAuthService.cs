using EmployeeManagementSystem.Data.Models;

namespace EmployeeManagementSystem.Modules.Auth.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string email, string password);
    }
}
