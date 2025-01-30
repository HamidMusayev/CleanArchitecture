using Application.DTOs;
using Application.Features.Products.Queries;
using AutoMapper;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }
}