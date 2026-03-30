using FluentValidation;
using Project_2.DTOs.SupplierDTOs;

namespace Project_2.Validators.SupplierValidators
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierValidator() 
        {
            RuleFor(s => s.Id)
                .GreaterThan(0);

            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(100); 

            RuleFor(s => s.ContactEmail)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
