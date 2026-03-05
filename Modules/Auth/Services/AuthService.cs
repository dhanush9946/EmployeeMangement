using EmployeeManagementSystem.Data.Models;
using EmployeeManagementSystem.Modules.Auth.Repositories;

namespace EmployeeManagementSystem.Modules.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await userRepository.GetUserByEmailAsync(email);

            if (user == null)
                return null;

            if (user.PasswordHash != password)
                return null;

            return user;
        }
    }
}