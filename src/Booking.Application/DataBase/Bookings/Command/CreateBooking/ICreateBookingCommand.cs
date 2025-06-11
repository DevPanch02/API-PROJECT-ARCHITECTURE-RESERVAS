namespace Booking.Application.DataBase.Bookings.Command.CreateBooking
{
    public interface ICreateBookingCommand
    {
        Task<CreateBookingModel> ExecuteAsync(CreateBookingModel model);
    }
}
