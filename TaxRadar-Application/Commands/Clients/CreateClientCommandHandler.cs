using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Clients;

public class CreateClientCommandHandler:IRequestHandler<CreateClientDto, ClientDto>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public CreateClientCommandHandler(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }
    public async Task<ClientDto> Handle(CreateClientDto request, CancellationToken cancellationToken)
    {
        var newClient = new Client(request.UserId, request.Name, request.Email,
            request.Ico,request.Dic,request.Street,request.City, request.PostalCode, request.Country);
        await _repository.AddAsync(newClient, cancellationToken);
        var createdClient = await _repository.GetByIdAsync(newClient.Id, cancellationToken);
        if (createdClient == null) throw new NotFoundException(nameof(Client), newClient.Id);
        return _mapper.Map<ClientDto>(newClient);

    }
}
