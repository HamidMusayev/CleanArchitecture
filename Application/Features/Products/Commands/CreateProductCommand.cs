using Application.DTOs;
using MediatR;

namespace Application.Features.Products.Commands;

public record CreateProductCommand(CreateProductDto Dto) : IRequest<ProductDto>;