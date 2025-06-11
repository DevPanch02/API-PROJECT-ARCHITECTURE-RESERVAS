namespace Booking.Application.DataBase.Bookings.Queries.GetBookingDocumentNumber
{
    public interface IGetBookingDocumentNumberQuery
    {
        Task<List<GetBookingDocumentNumberModel>> ExecuteAsync(string documentNumber);
    }
}
