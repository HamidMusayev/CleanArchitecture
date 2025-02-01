using Application.DTOs;
using Application.Features.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories.UnitOfWork;
using MediatR;

namespace Application.Features.Products.Handlers;

public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request.Dto);

        await productRepository.AddAsync(product);
        await unitOfWork.CommitAsync();

        return mapper.Map<ProductDto>(product);
    }
}