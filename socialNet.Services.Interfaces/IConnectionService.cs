﻿using socialNet.Data.Models;
using socialNet.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface IConnectionService
    {
        Task<ConnectionDto> AddConnection(ConnectionDto connectionDto);
        Task<ConnectionDto> RemoveConnection(ConnectionDto connectionDto);
        Task<IEnumerable<string>> GetFriendsConnectionId(int userId);
        Task<IEnumerable<string>> GetPostOwnerConnectionIds(int postId);
    }
}
