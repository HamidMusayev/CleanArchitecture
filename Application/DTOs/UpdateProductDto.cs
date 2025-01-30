namespace Application.DTOs;

public class UpdateProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}
