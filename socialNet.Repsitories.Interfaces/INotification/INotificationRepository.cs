using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repsitories.Interfaces.INotification
{
    public interface INotificationRepository: INotificationQueryRepository, INotificationCommandRepository
    {
    }
}
