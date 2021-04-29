using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface INotificationService
    {
        Task<bool> AddNewPostNotification(int userId);
    }
}
