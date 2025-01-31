using Application.DTOs;
using Application.Features.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class CreateProductHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request.Dto);

        context.Products.Add(product);
        await context.SaveChangesAsync();

        return mapper.Map<ProductDto>(product);
    }
}