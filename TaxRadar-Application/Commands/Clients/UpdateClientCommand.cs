using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Clients;

public class UpdateClientCommand(IRepository<Client> clientRepository, Guid clientId, IMapper mapper):IRequestHandler<UpdateClientDto, ClientDto>
{
    public async Task<ClientDto> Handle(UpdateClientDto request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetByIdAsync(clientId, cancellationToken);
        if (client == null) throw new NotFoundException(nameof(Client),clientId);
        
        client.UpdateDetails(request.Name, request.Email, request.Ico,request.Dic,request.Street,request.City,request.PostalCode,request.Country);
        await clientRepository.SaveChangesAsync(cancellationToken);
        return mapper.Map<ClientDto>(client);
    }
}