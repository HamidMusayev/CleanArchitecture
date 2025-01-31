using Application.DTOs;
using FluentValidation;

namespace Application.Features.Products.Validators;

public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than 0.");
    }
}