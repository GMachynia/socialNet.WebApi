using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
    public record  MyProfileDto(string Username, string FirstName, string LastName, string City, string ProfilePicture, IEnumerable<UserInvitationDto> Invitations);
 
}
