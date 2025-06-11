using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.Bookings.Queries.GetAllBooking
{
    public class GetAllBookingQuery: IGetAllBookingQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetAllBookingQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingModel>> ExecuteAsync()
        {
            //var bookings = await _dataBaseService.Booking.ToListAsync();
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer 
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingModel
                                {
                                    BookingId =  booking.BookingId,
                                    RegisterDate=booking.RegisterDate,
                                    Code=booking.Code,
                                    Type=booking.Type,
                                    CustomerFullName=customer.FullName,
                                    CustomerDocumentNumber=customer.DocumentNumber
                                }).ToListAsync();

            return result;
        }
    }
}
