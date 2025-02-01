using Domain.Common;

namespace Domain.Entities;

public class Product : IEntity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public Guid Id { get; set; }
}