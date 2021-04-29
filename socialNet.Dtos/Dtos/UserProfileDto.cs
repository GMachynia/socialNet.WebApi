using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
    public record UserProfileDto(string Username, string FirstName, string LastName, string City,  string ProfilePicture);
}
