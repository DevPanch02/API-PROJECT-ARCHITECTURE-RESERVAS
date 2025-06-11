using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.Bookings.Queries.GetBookingType
{
    public class GetBookingTypeQuery: IGetBookingTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingTypeModel>> ExecuteAsync(string type)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where booking.Type == type
                                select new GetBookingTypeModel
                                {
                                    RegisterDate = booking.RegisterDate,
                                    Code = booking.Code,
                                    Type = booking.Type,
                                    CustomerFullName=customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber
                                }).ToListAsync();
                                
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
