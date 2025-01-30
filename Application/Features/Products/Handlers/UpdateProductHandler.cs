using Application.Features.Products.Commands;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateProductHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null) return false;

        product.Name = request.Name;
        product.Price = request.Price;
        await _context.SaveChangesAsync();
        return true;
    }
}
