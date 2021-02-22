using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IConnection;
using System;
using System.Collections.Generic;
using System.Text;


namespace socialNet.Repositories
{
    public class ConnectionRepository: Repository<Connection>, IConnectionRepository
    {
        public ConnectionRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
