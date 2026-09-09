using MediatR;

namespace TaxRadar_Application.DTOs.Users;

public sealed record UpdateUserProfileDto(Guid Id, string FullName, string? Ico, string? Dic):IRequest<UserDto>;
