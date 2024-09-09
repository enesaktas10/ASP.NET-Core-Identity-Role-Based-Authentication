using AutoMapper;
using IdentityAuthentication.Dto;
using IdentityAuthentication.Models.Entities;

namespace IdentityAuthentication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
