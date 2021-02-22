using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class IsFriendRequestDto
    {
        public byte Status { get; set; }
        public string Username { get; set; }
        public string FriendUsername { get; set; }
    }
}
