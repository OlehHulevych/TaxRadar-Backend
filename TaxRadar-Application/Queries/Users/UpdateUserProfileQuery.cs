using MediatR;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_Application.Queries.Users;

public sealed record UpdateUserProfileQuery(Guid Id, string FullName, string? Ico, string? Dic):IRequest<UserDto>;
