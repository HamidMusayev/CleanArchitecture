using Application.DTOs;
using Application.Features.Products.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly AppDbContext _context;

    public GetProductByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        return product == null ? null : new ProductDto
        {
            Id = product.Id, 
            Name = product.Name, 
            Price = product.Price
        };
    }
}
