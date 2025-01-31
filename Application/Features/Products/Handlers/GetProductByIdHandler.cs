using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Products.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        return _mapper.Map<ProductDto>(product);
    }
}