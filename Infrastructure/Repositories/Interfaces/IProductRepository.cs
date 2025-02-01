using Domain.Entities;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
}