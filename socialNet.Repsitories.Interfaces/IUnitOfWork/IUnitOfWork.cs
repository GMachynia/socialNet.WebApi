using socialNet.Repsitories.Interfaces.IComment;
using socialNet.Repsitories.Interfaces.IConnection;
using socialNet.Repsitories.Interfaces.IFriendship;
using socialNet.Repsitories.Interfaces.IMessage;
using socialNet.Repsitories.Interfaces.INotification;
using socialNet.Repsitories.Interfaces.IPost;
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
        IMessageRepository Messages { get; }
        ICommentRepository Comments { get; }
        IConnectionRepository Connections { get; }
        IFriendshipRepository Friendships { get; }
        IPostRepository Posts { get; }
        INotificationRepository Notifications { get; }

        void Commit();
        Task<bool> CommitAsync();
    }
}
