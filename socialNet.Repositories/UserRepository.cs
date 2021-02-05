using socialNet.Data;
using socialNet.Repositories.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using socialNet.Data.Models;
using socialNet.Repsitories.Interfaces.IUser;
using Microsoft.EntityFrameworkCore;

namespace socialNet.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext) { }


        public async Task DeleteUserByIdAsync(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                Delete(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(user => user.Username == userName);
        }

        public async Task<bool> UserNameIsTaken(string userName)
        {
            return await _appDbContext.Users.AnyAsync(au => au.Username == userName);
        }

      
    }
}

