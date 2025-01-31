namespace Application.DTOs;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}