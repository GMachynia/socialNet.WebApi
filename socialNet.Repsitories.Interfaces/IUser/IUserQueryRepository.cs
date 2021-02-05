using socialNet.Data.Models;
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

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<bool> UserNameIsTaken(string username);
    }
}
