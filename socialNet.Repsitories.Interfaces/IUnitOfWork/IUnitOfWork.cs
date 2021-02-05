using socialNet.Repsitories.Interfaces.IUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        void Commit();
        Task<bool> CommitAsync();
    }
}
