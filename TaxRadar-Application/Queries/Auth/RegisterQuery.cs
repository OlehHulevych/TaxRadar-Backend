namespace TaxRadar_Application.Queries.Auth;

public sealed record RegisterQuery(string Email, string FullName, string Password);
