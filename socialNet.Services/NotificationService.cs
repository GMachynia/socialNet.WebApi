using AutoMapper;
using socialNet.Data.Models;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace socialNet.Services
{
    public class NotificationService: INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddNewPostNotification(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            var users = (List<User>) await _unitOfWork.Friendships.GetFriends(user);
            var notification = new Notification
            {
                Users = users, 
                NotificationType = NotificationType.NewPost
            };
            await _unitOfWork.Notifications.AddAsync(notification);
            return await _unitOfWork.CommitAsync();
        }

    }
}
