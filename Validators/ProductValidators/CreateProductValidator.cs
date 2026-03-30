using FluentValidation;
using Project_2.DTOs.ProductDTOs;

namespace Project_2.Validators.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        { 
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product name is required")
                .MaximumLength(100);
            
            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock cannot be negative");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be valid");

            RuleFor(p => p.SupplierId)
                .GreaterThan(0)
                .WithMessage("SupplierId must be valid");
        }
    }
}
