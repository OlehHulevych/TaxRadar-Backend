using MediatR;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_Application.Queries.Auth;

public sealed record RegisterQuery(string Email, string FullName, string Password):IRequest<UserDto>;
