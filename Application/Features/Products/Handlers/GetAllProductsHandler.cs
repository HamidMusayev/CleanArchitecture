using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Application.Features.Products.Handlers;

public class GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetListAsync();
        return mapper.Map<List<ProductDto>>(products);
    }
}