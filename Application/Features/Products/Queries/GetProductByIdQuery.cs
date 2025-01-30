using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;