namespace Booking.Application.DataBase.Bookings.Command.UpdateBooking
{
    public interface IUpdateBookingCommand
    {
        Task<UpdateBookingModel?> ExecuteAsync(UpdateBookingModel model);
    }
}
