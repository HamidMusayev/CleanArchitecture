using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers;

public class GetAllProductsHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await context.Products.ToListAsync();
        return mapper.Map<List<ProductDto>>(products);
    }
}