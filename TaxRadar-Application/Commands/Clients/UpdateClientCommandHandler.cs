using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Clients;

namespace TaxRadar_Application.Commands.Clients;

public class UpdateClientCommandHandler(IRepository<Client> clientRepository, IMapper mapper):IRequestHandler<UpdateClientQuery, ClientDto>
{
    public async Task<ClientDto> Handle(UpdateClientQuery request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetByIdAsync(request.Id, cancellationToken);
        if (client == null) throw new NotFoundException(nameof(Client),request.Id);
        
        client.UpdateDetails(request.Name, request.Email, request.Ico,request.Dic,request.Street,request.City,request.PostalCode,request.Country);
        await clientRepository.SaveChangesAsync(cancellationToken);
        return mapper.Map<ClientDto>(client);
    }
}