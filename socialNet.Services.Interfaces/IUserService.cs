using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Authenticate(string username, string password);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> GetById(int id);

        Task<UserDto> Create(SignUpRequestDto userDto);

        Task Update(UpdateUserRequestDto userDto);

        Task Delete(int id);
    }
    
}
