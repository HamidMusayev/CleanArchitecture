using Application.Features.Products.Commands;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories.UnitOfWork;
using MediatR;

namespace Application.Features.Products.Handlers;

public class DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetAsync(request.Id);
        if (product == null) return false;

        productRepository.Remove(product);
        await unitOfWork.CommitAsync();
        return true;
    }
}