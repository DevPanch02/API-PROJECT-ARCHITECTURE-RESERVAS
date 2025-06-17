using FluentValidation;

namespace Booking.Application.Validators.User
{
    public class GetUserPasswordValidator:AbstractValidator<(string, string)>
    {
        public GetUserPasswordValidator()
        {
            RuleFor(x=>x.Item1)
                .NotNull().WithMessage("User ID cannot be null.")
                .NotEmpty().WithMessage("User ID is required.")
                .MaximumLength(50).WithMessage("User ID must not exceed 50 characters.");

            RuleFor(x=>x.Item2)
                .NotNull().WithMessage("Password cannot be null.")
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        }
    }
}
