using FluentValidation;
using Project_2.DTOs.SupplierDTOs;

namespace Project_2.Validators.SupplierValidators
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(100); 

            RuleFor(s => s.ContactEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email format");
        }
    }
}
