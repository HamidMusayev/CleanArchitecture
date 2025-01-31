using Application.Features.Products.Commands;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProductHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Dto.Id);
        if (product == null) return false;

        _mapper.Map(request.Dto, product);
        await _context.SaveChangesAsync();

        return true;
    }
}