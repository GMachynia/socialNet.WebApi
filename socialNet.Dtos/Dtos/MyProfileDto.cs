using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
    public record  MyProfileDto(string Username, string FirstName, string LastName, string City, DateTime DateOfBirth, byte[] ProfilePicture, IEnumerable<UserInvitationDto> Invitations);
 
}
