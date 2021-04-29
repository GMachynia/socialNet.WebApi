using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.INotification;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
