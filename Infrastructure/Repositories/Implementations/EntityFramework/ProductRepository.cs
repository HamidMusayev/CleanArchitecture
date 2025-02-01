using Domain.Entities;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Repositories.GenericRepository;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations.EntityFramework;

public class ProductRepository(AppDbContext dbContext)
    : GenericRepository<Product>(dbContext), IProductRepository
{
    private readonly AppDbContext _dbContext = dbContext;
}