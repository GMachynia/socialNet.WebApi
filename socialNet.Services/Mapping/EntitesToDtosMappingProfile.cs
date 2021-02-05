using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos;

namespace socialNet.Services.Mapping
{
    public class EntitesToDtosMappingProfile : Profile
    {
        public EntitesToDtosMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}