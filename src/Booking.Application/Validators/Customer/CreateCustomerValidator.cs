using Booking.Application.DataBase.Customer.Command.CreateCustomer;
using FluentValidation;

namespace Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(50).WithMessage("Full name must not exceed 100 characters.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("Document number is required.")
                .Length(8).WithMessage("Document number must be exactly 11 characters.");
                //.Matches(@"^\d{11}$").WithMessage("Document number must be exactly 11 digits.");
        }
    }
}
