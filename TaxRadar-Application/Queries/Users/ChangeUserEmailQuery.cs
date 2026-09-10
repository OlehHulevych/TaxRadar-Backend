using MediatR;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_Application.Queries.Users;

public sealed record ChangeUserEmailQuery(Guid Id, string Email):IRequest<UserDto>;
