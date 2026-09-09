using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Users;

public class ChangeUserEmailCommandHandler(IRepository<User> repository, IMapper mapper ):IRequestHandler<ChangeUserEmailDto, UserDto>
{
    public async Task<UserDto> Handle(ChangeUserEmailDto request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null) throw new NotFoundException(nameof(User), request.Id);
        user.ChangeEmail(request.Email);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<UserDto>(user);

    }
}