﻿using Booking.Application.DataBase.User.Command.CreateUser;
using FluentValidation;

namespace Booking.Application.Validators.User
{
    public class CreateUserValidation: AbstractValidator<CreateUserModel>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First not null.")
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
