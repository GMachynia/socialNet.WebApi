using socialNet.Data;
using socialNet.Repositories.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using socialNet.Data.Models;
using socialNet.Repsitories.Interfaces.IUser;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using socialNet.Dtos;

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
            return await _appDbContext.Users.SingleOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(user => user.Username == userName);
        }

        public async Task<IEnumerable<string>> GetUsersByStringAsync(string usernameString)
        {
            return await _appDbContext.Users.Where(x => x.Username.StartsWith(usernameString)).Select(x =>
             x.Username).Take(8).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllUsersByStringAsync(string usernameString)
        {
            return await _appDbContext.Users.Where(x => x.Username.StartsWith(usernameString)).Select(x =>
             x.Username).ToListAsync();
        }
        public async Task<UserProfileDto> GetUserProfileAsync(string username)
        {
            return await _appDbContext.Users.Where(x => x.Username == username).Select(x =>
             new UserProfileDto(x.Username, x.FirstName, x.LastName, x.City, x.DateOfBirth, x.ProfilePicture)).SingleOrDefaultAsync();      
        }

        public async Task<bool> UserNameIsTaken(string userName)
        {
            return await _appDbContext.Users.AnyAsync(au => au.Username == userName);
        }

      
    }
}

