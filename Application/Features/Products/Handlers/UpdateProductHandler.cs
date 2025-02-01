using Application.Features.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories.UnitOfWork;
using MediatR;

namespace Application.Features.Products.Handlers;

public class UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request.Dto);

        productRepository.Update(product);
        await unitOfWork.CommitAsync();

        return true;
    }
}