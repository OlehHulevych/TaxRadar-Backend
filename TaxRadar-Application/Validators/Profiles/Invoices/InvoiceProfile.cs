using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Validators.Profiles.Invoices;

public class InvoiceProfile:Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForCtorParam(nameof(InvoiceDto.TotalGrossAmount), opt=>opt.MapFrom(src=>src.GetTotalGrossAmount().Amount));
        

    }
}