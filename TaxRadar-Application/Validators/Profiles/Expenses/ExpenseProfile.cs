using System.Xml.Serialization;
using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Expenses;

namespace TaxRadar_Application.Validators.Profiles.Expenses;

public class ExpenseProfile:Profile
{
    public ExpenseProfile()
    {
        CreateMap<Expense, ExpenseDto>()
            .ForCtorParam(nameof(ExpenseDto.Amount),
                org => org.MapFrom(src => src.Amount.Amount))
            .ForCtorParam(nameof(ExpenseDto.Currency), org => org.MapFrom(src => src.Amount.Currency));
    }
}