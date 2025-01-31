using Application.Features.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class UpdateProductHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request.Dto);

        context.Update(product);
        await context.SaveChangesAsync();

        return true;
    }
}