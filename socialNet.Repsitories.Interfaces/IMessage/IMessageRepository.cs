using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repsitories.Interfaces.IMessage
{
    public interface IMessageRepository: IMessageCommandRepository, IMessageQueryRepository
    {
    }
}
