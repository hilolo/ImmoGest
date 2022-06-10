using AutoMapper;
using ImmoGest.Application.DTOs.Building;
using ImmoGest.Application.DTOs.Client;
using ImmoGest.Application.DTOs.Hero;
using ImmoGest.Application.DTOs.Office;
using ImmoGest.Application.DTOs.Property;
using ImmoGest.Application.DTOs.Rental;
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
            CreateMap<Office, GetOfficeDTO>()
                
                .ReverseMap();
            CreateMap<CreateOfficeDto, Office>();
            CreateMap<UpdateOfficeDTO, Office>();


            // Client
            CreateMap<Client, GetClientDTO>()
          
                .ReverseMap();
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDTO, Client>();

            // Building
            CreateMap<Building, GetBuildingDTO>().ReverseMap();
            CreateMap<CreateBuildingDto, Building>();
            CreateMap<UpdateBuildingDTO, Building>();

            // Property
            CreateMap<Property, GetPropertyDTO>().ReverseMap();
            CreateMap<CreatePropertyDto, Property>();
            CreateMap<UpdatePropertyDTO, Property>();

            // Rental
            CreateMap<Rental, GetRentalDTO>().ReverseMap();
            CreateMap<CreateRentalDto, Rental>();
            CreateMap<UpdateRentalDTO, Rental>();




            // User Map
            CreateMap<User, GetUserDto>().ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(x => x.Role == Roles.Admin))
                .ForMember(dest => dest.OfficeName, act => act.MapFrom(src => src.Office.Name))
                .ReverseMap();
            CreateMap<CreateUserDto, User>().ForMember(dest => dest.Role,
                opt => opt.MapFrom(org => org.IsAdmin ? Roles.Admin : Roles.User));
            CreateMap<UpdatePasswordDto, User>();
            CreateMap<UpdateUserDto, User>();
            
        }
    }
}
