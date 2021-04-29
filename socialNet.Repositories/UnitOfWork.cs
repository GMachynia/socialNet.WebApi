using socialNet.Data;
using socialNet.Repsitories.Interfaces.IComment;
using socialNet.Repsitories.Interfaces.IConnection;
using socialNet.Repsitories.Interfaces.IFriendship;
using socialNet.Repsitories.Interfaces.IMessage;
using socialNet.Repsitories.Interfaces.INotification;
using socialNet.Repsitories.Interfaces.IPost;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Repsitories.Interfaces.IUser;
using System.Threading.Tasks;

namespace socialNet.Repositories.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _users;
        private IMessageRepository _messages;
        private ICommentRepository _comments;
        private IConnectionRepository _connections;
        private IFriendshipRepository _friendships;
        private IPostRepository _posts;
        private INotificationRepository _notifications;
   
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IUserRepository Users
        {
            get
            {
                return _users ??= new UserRepository(_context);
            }
        }
        public INotificationRepository Notifications
        {
            get
            {
                return _notifications ??= new NotificationRepository(_context);
            }
        }
        public IMessageRepository Messages
        {
            get
            {
                return _messages ??= new MessageRepository(_context);
            }
        }
        public ICommentRepository Comments
        {
            get
            {
                return _comments ??= new CommentRepository(_context);
            }
        }
        public IConnectionRepository Connections
        {
            get
            {
                return _connections ??= new ConnectionRepository(_context);
            }
        }
 
        public IFriendshipRepository Friendships
        {
            get
            {
                return _friendships ??= new FriendshipRepository(_context);
            }
        }
        public IPostRepository Posts
        {
            get
            {
                return _posts ??= new PostRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

