using Booking.Application.DataBase.User.Command.UpdateUserPassword;
using FluentValidation;

namespace Booking.Application.Validators.User
{
    public class UpdatePasswordUserValidation:AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdatePasswordUserValidation()
        {
            RuleFor(x=>x.UserId)
                .NotNull().WithMessage("User ID cannot be null.")
                .GreaterThan(0).WithMessage("User ID must be greater than zero.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password cannot be null.")
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");

        }
    }
}
