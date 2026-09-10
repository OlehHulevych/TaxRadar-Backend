using MediatR;

namespace TaxRadar_Application.Queries.Expenses;

public record DeleteExpenseQuery(Guid Id):IRequest;