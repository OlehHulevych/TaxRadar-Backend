using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Application.Commands.Users;

public class UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper):IRequestHandler<UpdateUserProfileDto, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserProfileDto request, CancellationToken cancellationToken)
    {
        var userForUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (userForUpdate == null) throw new NotFoundException(nameof(User), request.Id);
        userForUpdate.UpdateProfile(request.FullName,request.Ico, request.Dic);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<UserDto>(userForUpdate);
    }
}