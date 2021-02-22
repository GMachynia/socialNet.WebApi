using socialNet.Data.Models;
using socialNet.Repsitories.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repsitories.Interfaces.IMessage
{
    public interface IMessageCommandRepository : IRepository<Message>
    {
    }
}
