using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Modules.Auth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeManagementDbContext context;

        public UserRepository(EmployeeManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {

            
            return await context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        
    }
}
