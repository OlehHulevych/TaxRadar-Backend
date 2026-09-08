using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Clients;

public class DeleteClientCommandHandler(IRepository<Client> repository):IRequestHandler<DeleteClientDto>
{

    public async Task Handle(DeleteClientDto request, CancellationToken cancellationToken)
    {
        var client = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (client == null) throw new NotFoundException(nameof(Client), request.Id);
        await repository.DeleteAsync(client, cancellationToken);
    }
}
