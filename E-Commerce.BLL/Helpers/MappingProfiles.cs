using AutoMapper;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.DLL.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Item, ItemResponseDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));
        CreateMap<ItemRequestDTO, Item>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
        CreateMap<ItemTypeRequestDTO, ItemType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TypeName));
        CreateMap<RegisterDTO, User>();
        CreateMap<Order, OrderViewDTO>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

    }
}