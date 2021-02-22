using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IEmoticon;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repositories
{
    public class EmoticonRepository: Repository<Emoticon>, IEmoticonRepository
    {
        public EmoticonRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
