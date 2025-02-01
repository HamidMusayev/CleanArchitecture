using Application.DTOs;
using MediatR;

namespace Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;