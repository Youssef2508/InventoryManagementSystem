using FluentValidation;
using Project_2.DTOs.CategoryDTOs;

namespace Project_2.Validators.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MaximumLength(100);
        }
    }
}
