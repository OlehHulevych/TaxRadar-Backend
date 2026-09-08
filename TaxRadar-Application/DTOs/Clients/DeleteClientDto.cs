using MediatR;

namespace TaxRadar_Application.DTOs.Clients;

public sealed record DeleteClientDto(Guid Id):IRequest
{
    
}