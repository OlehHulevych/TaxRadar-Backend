using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Users;

namespace TaxRadar_Application.Commands.Users;

public class CreateUserCommandHandler(IRepository<User> repository, IMapper mapper):IRequestHandler<CreateUserQuery, UserDto>
{
    public async Task<UserDto> Handle(CreateUserQuery request, CancellationToken cancellationToken)
    {
        var newUser = new User(request.Email,request.FullName,request.Ico,request.Dic);
        await repository.AddAsync(newUser, cancellationToken);
        return mapper.Map<UserDto>(newUser);
    }
}