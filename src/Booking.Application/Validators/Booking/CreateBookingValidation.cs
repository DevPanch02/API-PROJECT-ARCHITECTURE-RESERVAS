using Booking.Application.DataBase.Bookings.Command.CreateBooking;
using FluentValidation;

namespace Booking.Application.Validators.Booking
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.RegisterDate)
                .NotEmpty().WithMessage("Register date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Register date cannot be in the future.");

            RuleFor(x => x.Code).MaximumLength(50)
                .WithMessage("Code cannot exceed 50 characters.")
                .NotEmpty().WithMessage("Code is required.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Must(type => type == "Hotel" || type == "Flight" || type == "Car")
                .WithMessage("Type must be either 'Hotel', 'Flight', or 'Car'.");

            RuleFor(x => x.CustomerId).NotNull().WithMessage("Customer ID is required.")
                .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.UserId).NotNull().WithMessage("User ID is required.").GreaterThan(0).WithMessage("User ID must be greater than 0.");
        }   
    }
}
