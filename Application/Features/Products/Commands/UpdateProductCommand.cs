using MediatR;

namespace Application.Features.Products.Commands;

public record UpdateProductCommand(int Id, string Name, decimal Price) : IRequest<bool>;
