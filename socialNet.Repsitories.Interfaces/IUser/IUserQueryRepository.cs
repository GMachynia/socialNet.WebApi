using socialNet.Data.Models;
using socialNet.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IUser
{
    public interface IUserQueryRepository
    {
        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByUsernameAsync(string username);

        Task<IEnumerable<string>> GetUsersByStringAsync(string usernameString);

        Task<IEnumerable<string>> GetAllUsersByStringAsync(string usernameString);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<UserProfileDto> GetUserProfileAsync(string username);

        Task<bool> UserNameIsTaken(string username);
    }
}
