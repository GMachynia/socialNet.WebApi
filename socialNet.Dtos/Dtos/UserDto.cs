using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
   public record UserDto(int UserId, string FirstName, string LastName, string Username);
}
