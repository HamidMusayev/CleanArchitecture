using Application.Features.Products.Commands;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class DeleteProductHandler(AppDbContext context) : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync(request.Id);
        if (product == null) return false;

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}