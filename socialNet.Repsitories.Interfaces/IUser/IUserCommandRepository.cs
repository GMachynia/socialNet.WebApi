using socialNet.Data.Models;
using socialNet.Repsitories.Interfaces.IRepository;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IUser
{
    public interface IUserCommandRepository: IRepository<User>
    {
        Task DeleteUserByIdAsync(int id);
    }
}
