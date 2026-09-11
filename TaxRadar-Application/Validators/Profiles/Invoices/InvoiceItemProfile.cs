using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Validators.Profiles.Invoices;

public class InvoiceItemProfile:Profile
{
    public InvoiceItemProfile()
    {
        CreateMap<InvoiceItem, InvoiceItemDto>()
            .ForCtorParam(nameof(InvoiceItemDto.UnitPrice), opt => opt.MapFrom(src => src.UnitPrice.Amount))
            .ForCtorParam(nameof(InvoiceItemDto.NetAmount), opt => opt.MapFrom(src => src.GetNetAmount().Amount))
            .ForCtorParam(nameof(InvoiceItemDto.VatAmount), opt => opt.MapFrom(src => src.GetVatAmount().Amount))
            .ForCtorParam(nameof(InvoiceItemDto.GrossAmount), opt => opt.MapFrom(src => src.GetGrossAmount().Amount));



    }
}