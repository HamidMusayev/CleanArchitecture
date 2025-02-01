using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Features.Products.Handlers;

public class GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetAsync(request.Id);
        return mapper.Map<ProductDto>(product);
    }
}