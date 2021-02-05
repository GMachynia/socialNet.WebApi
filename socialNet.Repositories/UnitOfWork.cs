using socialNet.Data;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Repsitories.Interfaces.IUser;
using System.Threading.Tasks;

namespace socialNet.Repositories.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _users;
   
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

