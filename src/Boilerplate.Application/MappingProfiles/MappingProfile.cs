using AutoMapper;
using ImmoGest.Application.DTOs.Client;
using ImmoGest.Application.DTOs.Hero;
using ImmoGest.Application.DTOs.Office;
using ImmoGest.Application.DTOs.User;
using ImmoGest.Domain.Auth;
using ImmoGest.Domain.Entities;

namespace ImmoGest.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Hero Map
            CreateMap<Hero, GetHeroDto>().ReverseMap();
            CreateMap<CreateHeroDto, Hero>();
            CreateMap<UpdateHeroDto, Hero>();

            // Office
            CreateMap<Office, GetOfficeDTO>().ReverseMap();
            CreateMap<CreateOfficeDto, Office>();
            CreateMap<UpdateOfficeDTO, Office>();


            // Client
            CreateMap<Client, GetClientDTO>().ReverseMap();
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDTO, Client>();



            // User Map
            CreateMap<User, GetUserDto>().ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(x => x.Role == Roles.Admin)).ReverseMap();
            CreateMap<CreateUserDto, User>().ForMember(dest => dest.Role,
                opt => opt.MapFrom(org => org.IsAdmin ? Roles.Admin : Roles.User));
            CreateMap<UpdatePasswordDto, User>();
        }
    }
}
