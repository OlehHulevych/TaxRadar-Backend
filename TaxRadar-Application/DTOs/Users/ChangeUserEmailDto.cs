using MediatR;

namespace TaxRadar_Application.DTOs.Users;

public sealed record ChangeUserEmailDto(Guid Id, string Email):IRequest<UserDto>;
