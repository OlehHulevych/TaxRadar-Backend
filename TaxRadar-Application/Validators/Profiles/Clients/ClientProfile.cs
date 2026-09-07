using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;

namespace TaxRadar_Application.Validators.Profiles.Clients;

public class ClientProfile:Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Email, opt =>
                opt.MapFrom(src => src.Email != null ? src.Email.Value : null))
            .ForMember(dest => dest.Ico, opt => opt.MapFrom(src => src.Ico == null ? src.Ico!.Value : null))
            .ForMember(dest => dest.Dic, opt => opt.MapFrom(src => src.Dic == null ? src.Dic!.Value : null))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address == null ? src.Address!.Street : null))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address == null ? src.Address!.City : null))
            .ForMember(dest => dest.PostalCode,
                opt => opt.MapFrom(src => src.Address == null ? src.Address!.PostalCode : null))
            .ForMember(dest => dest.Country,
                opt => opt.MapFrom(src => src.Address == null ? src.Address!.Country : null));
        CreateMap<Client, ClientDto>();



    }
}