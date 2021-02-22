using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class UpdateFriendshipStatusRequestDto
    {
        public string FriendUsername { get; set; }
        public byte Status { get; set; }
    }
}
