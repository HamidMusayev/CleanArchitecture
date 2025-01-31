using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class GetProductByIdHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync(request.Id);
        return mapper.Map<ProductDto>(product);
    }
}