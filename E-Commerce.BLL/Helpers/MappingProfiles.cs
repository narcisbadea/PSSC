using AutoMapper;
using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.DLL.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Item, ItemResponseDTO>()
            .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType.Name));
        CreateMap<ItemRequestDTO, Item>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
        CreateMap<ItemTypeRequestDTO, ItemType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ItemTypeName)); ;
    }
}