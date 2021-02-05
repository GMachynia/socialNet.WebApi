using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repsitories.Interfaces.IUser
{
    public interface IUserRepository: IUserCommandRepository, IUserQueryRepository
    {
    }
}
