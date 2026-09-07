using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;

namespace TaxRadar_Application.Validators.Profiles.Clients;

public class ClientProfile:Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForCtorParam(nameof(ClientDto.Email), opt =>
                opt.MapFrom(src => src.Email != null ? src.Email.Value : null))
            .ForCtorParam(nameof(ClientDto.Ico), opt => opt.MapFrom(src => src.Ico != null ? src.Ico.Value : null))
            .ForCtorParam(nameof(ClientDto.Dic), opt => opt.MapFrom(src => src.Dic != null ? src.Dic.Value : null))
            .ForCtorParam(nameof(ClientDto.Street), opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : null))
            .ForCtorParam(nameof(ClientDto.City), opt => opt.MapFrom(src => src.Address != null ? src.Address.City : null))
            .ForCtorParam(nameof(ClientDto.PostalCode),
                opt => opt.MapFrom(src => src.Address != null ? src.Address.PostalCode : null))
            .ForCtorParam(nameof(ClientDto.Country),
                opt => opt.MapFrom(src => src.Address != null ? src.Address.Country : null));



    }
}