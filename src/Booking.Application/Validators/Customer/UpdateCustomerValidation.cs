using Booking.Application.DataBase.Customer.Command.UpdateCustomer;
using FluentValidation;

namespace Booking.Application.Validators.Customer
{
    internal class UpdateCustomerValidation:AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidation()
        {
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x=>x.FullName).NotNull().NotEmpty().MaximumLength(50).WithMessage("Full name must not exceed 50 characters.");
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
        }
    }
}
