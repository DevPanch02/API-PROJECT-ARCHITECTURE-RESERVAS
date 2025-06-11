using Booking.Application.DataBase.User.Command.CreateUser;
using Booking.Application.DataBase.User.Command.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Validators.User
{
    public class UpdateUserValidation: AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("User ID cannot be null.")
                .GreaterThan(0).WithMessage("User ID must be greater than zero.");

            RuleFor(x=>x.FirstName)
                .NotNull().WithMessage("First name cannot be null.")
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("First name is required.")
                .MaximumLength(10).WithMessage("Email must not exceed 10 characters.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password not null.")
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(3).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");


        }
    }
}
