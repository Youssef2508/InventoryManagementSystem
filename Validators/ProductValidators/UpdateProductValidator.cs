using FluentValidation;
using Project_2.DTOs.ProductDTOs;

namespace Project_2.Validators.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("Invalid product Id"); 

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
                .GreaterThan(0);

            RuleFor(p => p.SupplierId)
                .GreaterThan(0);
        }
    }
}
