using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos.RequestDtos;

namespace socialNet.Services.Mapping
{
    public class DtosToEntitiesMappingProfile : Profile
    {
        public DtosToEntitiesMappingProfile()
        {
            CreateMap<SignUpRequestDto, User>();
            CreateMap<UpdateUserRequestDto, User>();
        }
    }
}