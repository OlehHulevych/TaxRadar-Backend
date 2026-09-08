using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Clients;

public class GetClientCommandHandler(IRepository<Client> repository, IMapper mapper):IRequestHandler<GetClientDetails, ClientDto>
{
    public async Task<ClientDto> Handle(GetClientDetails request, CancellationToken cancellationToken)
    {
        var client = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (client == null) throw new NotFoundException(nameof(Client), request.Id);
        return mapper.Map<ClientDto>(client);
    }
}
