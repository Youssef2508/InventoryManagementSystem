using FluentValidation;
using Project_2.DTOs.CategoryDTOs;

namespace Project_2.Validators.CategoryValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator() 
        { 
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MaximumLength(100);
        }
    }
}
